using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace AspNetWebApiSample
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.MessageHandlers.Add(new CorrelationIdDelegatingHandler());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }

    public class CorrelationIdDelegatingHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string correlationId = null;
            var headerName = "correlation-id";
            if (request.Headers.Contains(headerName))
            {
                request.Headers.TryGetValues(headerName, out var values);
                correlationId = values.FirstOrDefault();
            }
            else
            {
                correlationId = Guid.NewGuid().ToString();
                request.Headers.Add(headerName, correlationId);
            }

            var response = await base.SendAsync(request, cancellationToken);

            response.Headers.Add(headerName, correlationId);

            return response;
        }
    }
}
