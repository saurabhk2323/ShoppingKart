using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;

namespace InventoryManagement.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                _logger.LogInformation("Request started: {Method} {Path} TraceId: {TraceId}", context.Request.Method, context.Request.Path, Activity.Current?.Id ?? context.TraceIdentifier);
                await _next(context); // move to next middleware
            }
            catch (Exception ex)
            {
                var traceId = Activity.Current?.Id ?? context.TraceIdentifier;

                _logger.LogError(ex, "Unhandled exception occurred. TraceId: {TraceId}", traceId);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var errorResponse = new
                {
                    success = false,
                    statusCode = context.Response.StatusCode,
                    error = "Internal Server Error",
                    details = new[] { ex.Message },
                    traceId = traceId
                };

                var json = JsonConvert.SerializeObject(errorResponse);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
