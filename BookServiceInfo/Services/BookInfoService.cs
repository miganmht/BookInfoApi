using BookinfoCommon.Interfaces;
using BookinfoCommon.Models;
using BookServiceInfo.Data;
using System.Net.Http.Json;

namespace BookServiceInfo.Services
{
    public class BookInfoService : IBookInfoService
    {
        private readonly HttpClient _httpClient;
        private readonly InMemoryCache<BookInfo> inMemoryCache;
        public BookInfoService()
        {
            _httpClient = new HttpClient();
            inMemoryCache = InMemoryCache<BookInfo>.Getinstance();
        }
        public async Task<BookInfo> GetBookById(string id)
        {
            if (inMemoryCache.TryGetValue(id, out var bookInfo)) {
                return bookInfo;
            }
            else
            {
                var res = await GetDataFromThirdParty(id);
                if (res != null) { 
                    inMemoryCache.TryAddAsync(id, res);
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
