using BookinfoCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookinfoCommon.Interfaces
{
    public interface IBookInfoService
    {

        Task<BookInfo> GetBookById(string id);
        Task RemoveFromCache(string bookid);

    }
}
