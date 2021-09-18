using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace PostTodo
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var post = new Post
            {
                Id = 101,
                UserId = 1020,
                Body = "Body test",
                Title = "Test 1"
            };

            var client = new HttpClient();
            //client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");


            var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Post;
            httpRequestMessage.RequestUri = new Uri("https://jsonplaceholder.typicode.com/posts");
            //foreach (var head in pHeaders)
            //{
            //    httpRequestMessage.Headers.Add(head.Key, head.Value);
            //}

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(post), Encoding.UTF8, "application/json");
            httpRequestMessage.Content = httpContent;

            var result = await client.SendAsync(httpRequestMessage);

            Console.WriteLine("-----------------");
        }
    }
}
