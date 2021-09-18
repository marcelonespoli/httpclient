using Api.Client;
using API.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
                
        public void ConfigureServices(IServiceCollection services)
        {
            // let get context informations to use 
            services.AddHttpContextAccessor();

            // register the middleware
            services.AddTransient<HttpContextMiddleware>();

            services.AddHttpClient<TodoRepository>("simple", client =>
            {
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
                client.DefaultRequestHeaders.Add("StartupHeader", Guid.NewGuid().ToString());
            });

            services.AddHttpClient<UserRepository>(client =>
            {
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
            })
                .AddHttpMessageHandler<HttpContextMiddleware>();
            //.SetHandlerLifetime(TimeSpan.FromSeconds(1)); 

            // addd by library, it is a way to create a library and share it with other API (microsorvices)
            services.AddApiClient();
            services.ApiClientWithNoConfiguration(client =>
            {
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }
                
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
