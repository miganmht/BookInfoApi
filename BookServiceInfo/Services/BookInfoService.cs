using BookinfoCommon.Interfaces;
using BookinfoCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookServiceInfo.Services
{
    public class BookInfoService : IBookInfoService
    {
        public async Task<Book> GetBookById(string id)
        {
            return new Book()
            {
                id = id,
                info="test"
            };
        }
    }
}
