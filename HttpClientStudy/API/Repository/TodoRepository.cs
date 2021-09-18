using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using System.Net.Http.Json;

namespace API.Repository
{
    public class TodoRepository
    {
        private readonly HttpClient _httpClient;
        
        public TodoRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetAll() 
        {
            var apiUrl = "/todos";
            var response = await _httpClient.GetAsync(apiUrl);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
