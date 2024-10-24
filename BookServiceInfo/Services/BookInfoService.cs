using BookinfoCommon.Interfaces;
using BookinfoCommon.Models;
using BookServiceInfo.Data;
using RedisManager;
using System.Net.Http.Json;

namespace BookServiceInfo.Services
{
    public class BookInfoService : IBookInfoService
    {
        private readonly HttpClient _httpClient;
        private readonly InMemoryCache<BookInfo> inMemoryCache;
        private readonly RedisCacheService<BookInfo> inRedisCache;
        public BookInfoService(HttpClient httpClient, InMemoryCache<BookInfo> inMemoryCache, RedisCacheService<BookInfo> inRedisCache)
        {
            
            this._httpClient = httpClient;
            this.inMemoryCache = inMemoryCache;
            this.inRedisCache = inRedisCache;
        }
        public async Task<BookInfo> GetBookById(string id)
        {
            if (inMemoryCache.TryGetValue(id, out var bookInfo)) {
                return bookInfo;
            }
            
            else if(inRedisCache.TryGetValue(id,out var redisbook))
            {
                return redisbook;
            }
            else
            {
                var res = await GetDataFromThirdParty(id);
                if (res != null) { 
                    inMemoryCache.TryAddAsync(id, res);
                    inRedisCache.TryAddAsync(id, res);
                }
                return res;
            }
            
        }
    
        public async Task<BookInfo> GetDataFromThirdParty(string id)
        {
            var response = await _httpClient.GetAsync($"https://get.taaghche.com/v2/book/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<BookInfo>();
            }
            return null;
        }
    
    
    }
}
