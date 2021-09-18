using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

// intaled package Microsoft.Extensions.Http

namespace Api.Client
{
    public static class ApiClientRegister
    {
        public static IServiceCollection AddApiClient(this IServiceCollection services)
        {
            // register the middleware
            services.AddTransient<HttpContextMiddlewareCustom>();

            services.AddHttpClient<CustomRepository>(client =>
            {
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
            })
                .AddHttpMessageHandler<HttpContextMiddlewareCustom>();

            return services;
        }
    }
}
