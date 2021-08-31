using BusinessLogicLibrary;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebApiSample
{
    public class CorrelationIdAccessor : ICorrelationIdAccessor
    {
        private readonly IHttpContextAccessor _httpContextAcessor;

        public CorrelationIdAccessor(IHttpContextAccessor httpContextAcessor)
        {
            _httpContextAcessor = httpContextAcessor;
        }

        public string GetCorrelationId()
        {
            var request = _httpContextAcessor.HttpContext.Request;
            if (request.Headers.TryGetValue("correlation-id", out var correlationId))
            {
                return correlationId;
            }
            return null;
        }
    }
}
