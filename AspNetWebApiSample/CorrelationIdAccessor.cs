using BusinessLogicLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetWebApiSample
{
    public class CorrelationIdAccessor : ICorrelationIdAccessor
    {
        private readonly IHttpContextAccessor _httpContextWrapper;

        public CorrelationIdAccessor(IHttpContextAccessor httpContextWrapper)
        {
            _httpContextWrapper = httpContextWrapper;
        }

        public string GetCorrelationId()
        {
            var request = _httpContextWrapper.GetCurrentHttpContext().Request;
            return null;
        }
    }

    public interface IHttpContextAccessor
    {
        HttpContext GetCurrentHttpContext();
    }

    public class HttpContextAccessor : IHttpContextAccessor
    {
        public HttpContext GetCurrentHttpContext()
        {
            return HttpContext.Current;
        }
    }
}