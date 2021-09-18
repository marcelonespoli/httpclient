using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace Api.Client
{
    public class CustomRepository
    {
        private readonly HttpClient _httpClient;
        
        public CustomRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<string> GetAll() 
        {
            var apiUrl = "/users";
            return _httpClient.GetFromJsonAsync<string>(apiUrl);
        }
    }
}
