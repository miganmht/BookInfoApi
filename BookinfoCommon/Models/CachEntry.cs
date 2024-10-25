using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookinfoCommon.Models
{
    public class CachEntry<T>
    {
        public T Value { get; set; }
        public DateTime Expiration { get; set; }
    }
}
