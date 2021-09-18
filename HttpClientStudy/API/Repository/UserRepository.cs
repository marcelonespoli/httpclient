using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.Repository
{
    public class UserRepository
    {
        private readonly HttpClient _httpClient;
        
        public UserRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetAll() 
        {
            var apiUrl = "/users";
            var response = await _httpClient.GetAsync(apiUrl);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
