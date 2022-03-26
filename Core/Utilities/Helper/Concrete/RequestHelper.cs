using Common.Helper.Abstract;
using Microsoft.AspNetCore.Http; 

namespace Common.Helper.Concrete
{
    public class RequestHelper : IRequestHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RequestHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetIpAddress()
        {
            return _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
        }

        public HttpContext Context => _httpContextAccessor.HttpContext;
    }
}
