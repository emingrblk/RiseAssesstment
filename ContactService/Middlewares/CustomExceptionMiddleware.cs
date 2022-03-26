using Business.Abstract;
using Common.Helper.Abstract;
using Entities.Concrete.DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks; 

namespace ContactService.Middlewares
{
    public static class ConfigureCustomExceptionMiddleware
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMiddlewareLogService _middlewareLogService;
        private readonly IRequestHelper _requestHelper;
        public CustomExceptionMiddleware(RequestDelegate next, IMiddlewareLogService middlewareLogService, IRequestHelper requestHelper)
        {
            _next = next;
            _middlewareLogService = middlewareLogService;
            _requestHelper = requestHelper;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
             await   _middlewareLogService.AddAsync(new MiddlewareLogDto() { LogMethod = httpContext.Request?.Path.Value, ControllerName= ex.TargetSite?.DeclaringType?.Name, CreatedDate = DateTime.Now, LogMessage = ex.ToString(), UserIp = _requestHelper.GetIpAddress()});
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.Redirect("/Error/500");
            }
        }
    }
}
