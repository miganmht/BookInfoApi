using BookinfoCommon.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookServiceInfo.Data
{
    public class InMemoryCache<T> : ICache<T>
    {
        private ConcurrentDictionary<string, T> _catch=new ConcurrentDictionary<string, T>();
        private static InMemoryCache<T> _instance { get; set; }
        private InMemoryCache() {
        
        
        }
        public static InMemoryCache<T> Getinstance()
        {
            if (_instance == null)
            {
                _instance = new InMemoryCache<T>();
            }
            return _instance;
        }
        public bool TryAdd(string key, T value)
        {
            return _catch.TryAdd(key, value);
        }

        public void Remove(string key)
        {

            _catch.TryRemove(key,out _);
        }

        public bool TryGetValue(string key, out T value)
        {
            if(_catch.TryGetValue(key,out value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Task<bool> TryAddAsync(string key, T value)
        {
            return Task.Run(() => {return TryAdd(key,value); });
        }
    }
}
