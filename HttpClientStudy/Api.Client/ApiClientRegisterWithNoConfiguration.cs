using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

// it needs intalled package "Microsoft.Extensions.Http"

namespace Api.Client
{
    public static class ApiClientRegisterWithNoConfiguration 
    {
        public static IServiceCollection ApiClientWithNoConfiguration(
            this IServiceCollection services, 
            Action<HttpClient> clientConfiguration)
        {
            // register the middleware
            services.AddTransient<HttpContextMiddlewareCustom>();

            services.AddHttpClient<CustomRepository>(clientConfiguration)
                .AddHttpMessageHandler<HttpContextMiddlewareCustom>();

            return services;
        }
    }
}
