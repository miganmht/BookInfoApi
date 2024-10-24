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
    public class RedisCacheService<T> : ICache<T>
    {
        private readonly IConnectionMultiplexer _redis;
        private readonly IDatabase _db;
        public RedisCacheService(IConnectionMultiplexer redis)
        {
            _redis = redis;
            _db = _redis.GetDatabase();

        }
        public async void Remove(string key)
        {
           await _db.KeyDeleteAsync(key);
        }

        public bool TryAdd(string key, T value)
        {
            var json=Newtonsoft.Json.JsonConvert.SerializeObject(value);
            return _db.StringSet("book:"+key, json);
        }

        public async Task<bool> TryAddAsync(string key, T value)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(value);
            return  await _db.StringSetAsync("book:"+key, json);
        }

        public bool TryGetValue(string key, out T value)
        {
            var book=_db.StringGet($"book:{key}");
            if (!string.IsNullOrEmpty(book))
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(book);
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
