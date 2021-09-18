using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace API.Repository
{
    public class HttpContextMiddleware : DelegatingHandler
    {
        private string _ctor;
        private readonly IHttpContextAccessor _acessor; // jut to know how validate thing into the context here

        public HttpContextMiddleware(IHttpContextAccessor acessor)
        {
            _ctor = Guid.NewGuid().ToString();
            _acessor = acessor;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            CheckAnythingIntoTheUser();


            var method = Guid.NewGuid().ToString();

            request.Headers.Add("Meddleware-Ctor", _ctor);
            request.Headers.Add("Meddleware-Method", method);

            return base.SendAsync(request, cancellationToken);
        }

        private void CheckAnythingIntoTheUser()
        {
            var httpContext = _acessor.HttpContext;
            if (httpContext.User == null)
            {
                // do something
            }
        }
    }
}
