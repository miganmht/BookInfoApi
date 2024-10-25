using BookinfoCommon.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookServiceInfo.Data
{
    public class InMemoryCache<T> : CacheServiceAbsteract,ICache<T>
    {
        private ConcurrentDictionary<string, T> _cache=new ConcurrentDictionary<string, T>();
        private ConcurrentDictionary<string,DateTime> _expiertime=new ConcurrentDictionary<string,DateTime>();
        private readonly object _lock = new object();
        private Timer timerformemory { get; set; }
        
        public InMemoryCache(int minuteperiod) {

            
            _cleanupInterval = minuteperiod ;
            var timespaninmemory = TimeSpan.FromMinutes(_cleanupInterval);
            timerformemory = new Timer(CleanCache, null, TimeSpan.Zero, timespaninmemory);

        }
   
        public bool TryAdd(string key, T value)
        {
            _expiertime.TryAdd(key, DateTime.Now.AddMinutes(_cleanupInterval));
            return _cache.TryAdd(key, value);
        }
        public void CleanCache(object ob)
        {
            var expierdkeylist = _expiertime.Where(aa => DateTime.Now>aa.Value)
                .Select(aa=>aa.Key).ToList();
            foreach(var item in expierdkeylist)
            {
                var exp = _expiertime.Where(aa=>aa.Key==item).First();
                
                _expiertime.TryRemove(exp);

                var expcache = _cache.Where(aa => aa.Key == item).First();

                _cache.TryRemove(expcache);

            }
        }
        public async void Remove(string key)
        {

           _cache.TryRemove(key,out _);
        }

        public bool TryGetValue(string key, out T value)
        {
            if(_cache.TryGetValue(key,out value))
            {
                _expiertime.TryGetValue(key,out var expiertime);
                if (expiertime < DateTime.Now)
                {
                    Remove(key);
                    value = default;
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public Task<bool> TryAddAsync(string key, T value)
        {
           
            return Task.Run(() => {
                _expiertime.TryAdd(key, DateTime.Now.AddMinutes(_cleanupInterval));
                return TryAdd(key,value); });
        }

       
    }
}
