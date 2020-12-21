using Microsoft.AspNetCore.Http;
using ReadApi.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ReadApi.CustomExceptionMiddleware
{
    /// <summary>
    /// After the registration process, we need to create the InvokeAsync() method. 
    /// RequestDelegate can’t process requests without it.

    /// If everything goes well, the _next delegate should process the request 
    /// and the Get action from our controller should generate a successful response. 
    /// But if a request is unsuccessful (and it is, because we are forcing exception), 
    /// our middleware will trigger the catch block and call the HandleExceptionAsync method.
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _logger;

        public ExceptionMiddleware(RequestDelegate next, ILoggerManager logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            }.ToString());;
        }
    }
}
