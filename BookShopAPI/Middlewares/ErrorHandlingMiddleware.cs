using System;
using System.Threading.Tasks;
using BookShopAPI.Constants;
using BookShopAPI.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace BookShopAPI.Middlewares
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (NotFoundException ex)
            {
                context.Response.StatusCode = ResponseCode.NotFoundException;
                await context.Response.WriteAsync(ex.Message);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                context.Response.StatusCode = ResponseCode.InternalServerError;
                await context.Response.WriteAsync(LogMessage.InternalServerError);
            }
        }
    }
}
