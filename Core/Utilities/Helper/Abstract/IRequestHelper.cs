using Microsoft.AspNetCore.Http;

namespace Common.Helper.Abstract
{
    public interface IRequestHelper
    {
        string GetIpAddress();
        HttpContext Context { get; }
    }
}
