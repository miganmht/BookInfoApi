using BookinfoCommon.Interfaces;
using BookinfoCommon.Models;
using System.Net.Http.Json;

namespace BookServiceInfo.Services
{
    public class BookInfoService : IBookInfoService
    {
        private readonly HttpClient _httpClient;
        public BookInfoService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<BookInfo> GetBookById(string id)
        {
            return await GetDataFromThirdParty(id);
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
