using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Client
{
    public class HttpContextMiddlewareCustom : DelegatingHandler
    {
        private string _ctor;

        public HttpContextMiddlewareCustom()
        {
            _ctor = Guid.NewGuid().ToString();
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var method = Guid.NewGuid().ToString();

            request.Headers.Add("Meddleware-Ctor", _ctor);
            request.Headers.Add("Meddleware-Method", method);

            return base.SendAsync(request, cancellationToken);
        }

    }
}
