using BookinfoCommon.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;
using System.Text.Json;
using BookinfoCommon.Models;
namespace RedisManager
{
    public class RedisCacheService<T> : CacheServiceAbsteract, ICache<T>
    {
        private readonly IConnectionMultiplexer _redis;
        private readonly IDatabase _db;
       
        private Timer timerforredis { get; set; }

        public RedisCacheService(IConnectionMultiplexer redis,int minuteperiod)
        {
            
            _redis = redis;
            _db = _redis.GetDatabase();
            _cleanupInterval = minuteperiod;
            var timspanredis = TimeSpan.FromMinutes(_cleanupInterval);

            timerforredis = new Timer(CleanCache, null, TimeSpan.Zero, timspanredis);
        }

        public void CleanCache(object ob)
        {
            var server = _redis.GetServer(_redis.Configuration);
            var keys=server.Keys();
            foreach (var key in keys) { 
            
                var value=_db.StringGet(key);
                try
                {
                    var cachentry=Newtonsoft.Json.JsonConvert.DeserializeObject<CachEntry<T>>(value);
                    if (cachentry.Value == null)
                    {
                        continue;
                    }
                    if (cachentry.Expiration<=DateTime.Now)
                    {
                        _db.KeyDelete(key);
                    }
                }
                catch (Exception ex) { 
                
                }
             
            
            }
        }

        public  void Remove(string key)
        {
            _db.KeyDelete("book:"+key);
        }

        public bool TryAdd(string key, T value)
        {
            var cacheentry = new CachEntry<T>()
            {
                Value = value,
                Expiration = DateTime.Now.AddMinutes(_cleanupInterval),
            };
            var json=Newtonsoft.Json.JsonConvert.SerializeObject(cacheentry);
            return _db.StringSet("book:"+key, json);
        }

        public async Task<bool> TryAddAsync(string key, T value)
        {
            var cacheentry = new CachEntry<T>()
            {
                Value = value,
                Expiration = DateTime.Now.AddMinutes(_cleanupInterval),
            };
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(cacheentry);
            return  await _db.StringSetAsync("book:"+key, json);
        }

        public bool TryGetValue(string key, out T value)
        {
            var book=_db.StringGet($"book:{key}");
            if (!string.IsNullOrEmpty(book))
            {
                var res= Newtonsoft.Json.JsonConvert.DeserializeObject<CachEntry<T>>(book);
                if (res.Expiration < DateTime.Now)
                {
                    Remove(key);
                    value = default;
                    return false;
                }
                value = res.Value;
                
                return true;
            }
            else
            {
                value = default;
                return false;
            }
        }
    
       
    }
}
