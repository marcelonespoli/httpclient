using Scheduler.Business.Models;
using Scheduler.Business.Services.Enum;
using Scheduler.Business.Services.Interfaces;
using Enterprise.Common.Authentication.Services.BearerToken;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Scheduler.Business.Config;
using Microsoft.Extensions.Options;

namespace Scheduler.Business.Services
{
    public class HttpClientService : IHttpClientService
	{
        private HttpClient _httpClient;
        private readonly AppSettings _options;
        private readonly IBearerTokenService _bearerTokenService;

        public HttpClientService(
            IOptions<AppSettings> options, 
            IBearerTokenService bearerTokenService)
        {
            _options = options.Value;
            _bearerTokenService = bearerTokenService;
        }

        public async Task<Notification> Get(string url, HttpClient httpClient = null)
		{
            GetHttpClient(httpClient);
            return await ProcessRequest(url, SendMethod.GET);
		}

		public async Task<Notification> Post(string url, string data, HttpClient httpClient = null)
		{
            GetHttpClient(httpClient);
            return await ProcessRequest(url, SendMethod.POST, data);
		}

		public async Task<Notification> Put(string url, string data, HttpClient httpClient = null)
		{
            GetHttpClient(httpClient);
            return await ProcessRequest(url, SendMethod.PUT, data);
		}

		public async Task<Notification> Delete(string url, HttpClient httpClient = null)
		{
            GetHttpClient(httpClient);
            return await ProcessRequest(url, SendMethod.DELETE);
		}

        // important to mock the httpclient on the unit tests
        private void GetHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? new HttpClient();
        }

   
        private async Task<Notification> ProcessRequest(string url, SendMethod method, string data = null)
		{
			try
			{
                _httpClient.BaseAddress = new Uri(url);

                await PrepareRequestHeaders();

                var response = await ProcessMethod(url, method, data, _httpClient);
                if (response.IsSuccessStatusCode)
				{
					var result = await response.Content.ReadAsStringAsync();
					return new Notification
					{
                        Statuscode = response.StatusCode,
                        Success = true,
						Data = result
					};
				}
                                
                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return new Notification
                    {
                        Statuscode = response.StatusCode,
                        Success = false,
                        Error = result
                    };
                }

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return new Notification
                    {
                        Statuscode = response.StatusCode,
                        Success = false,
                        Error = response.ReasonPhrase
                    };
                }

                return new Notification();
			}
			catch (Exception ex)
			{
				return new Notification
				{
                    Success = false,
					Error = ex.Message
				};
			}
		}

		private async Task<HttpResponseMessage> ProcessMethod(string url,
				SendMethod method, string data, HttpClient client)
		{
			switch (method)
			{
				case SendMethod.GET:
					return await client.GetAsync(url);
				case SendMethod.POST:
					var httpPostContent = new StringContent(data, Encoding.UTF8, "application/json");
					return await client.PostAsync(url, httpPostContent);
				case SendMethod.PUT:
					var httpPutContent = new StringContent(data, Encoding.UTF8, "application/json");
					return await client.PutAsync(url, httpPutContent);
				case SendMethod.DELETE:
					return await client.DeleteAsync(url);
				default:
					return new HttpResponseMessage();
			}
		}

        private async Task PrepareRequestHeaders()
        {
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _httpClient.DefaultRequestHeaders.Add("Oab-Addim-Subscription-Key", _options.OabAddimSubscriptionKey);

            var token = await _bearerTokenService.GetToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

	}

}
