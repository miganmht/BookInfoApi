using BookinfoCommon.Interfaces;
using BookinfoCommon.Models;
using MassTransit;
using RedisManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookServiceInfo.Data
{
    public class BookInfoChangedConsumer : IConsumer<BookInfoChanged>
    {
        private readonly ICache<BookInfo> _inMemoryCache;
        private readonly ICache<BookInfo> _redisCache;
        public BookInfoChangedConsumer(InMemoryCache<BookInfo> inMemoryCache, RedisCacheService<BookInfo> redisCache)
        {
            _inMemoryCache = inMemoryCache;
            _redisCache = redisCache;
        }
        public Task Consume(ConsumeContext<BookInfoChanged> context)
        {
            var bookId = context.Message.BookId;
            Console.WriteLine($"Book id consume {bookId}");
            return Task.Run(() => {
                _inMemoryCache.Remove(bookId);
                _redisCache.Remove(bookId);
            });
           
          
        }
    }
}
