using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookinfoCommon.Interfaces
{
    public interface ICache<T>
    {

         Task<bool> TryAddAsync(string key, T value);
    

        bool TryAdd(string key, T value);

        
        bool TryGetValue(string key, out T value);

        
        void Remove(string key);

        
  


    }
}
