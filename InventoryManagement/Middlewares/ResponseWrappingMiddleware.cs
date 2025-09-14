using Newtonsoft.Json;
using System.Diagnostics;

namespace InventoryManagement.Middlewares
{
    public class ResponseWrappingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ResponseWrappingMiddleware> _logger;

        public ResponseWrappingMiddleware(RequestDelegate next, ILogger<ResponseWrappingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var request = context.Request;
            var traceId = Activity.Current?.Id ?? context.TraceIdentifier;
            _logger.LogInformation("Request started: {Method} {Path} TraceId: {TraceId}", request.Method, request.Path, traceId);

            var originalBodyStream = context.Response.Body;
            using var tempMemoryStream = new MemoryStream();
            context.Response.Body = tempMemoryStream;

            await _next(context);

            tempMemoryStream.Seek(0, SeekOrigin.Begin);
            var bodyText = await new StreamReader(tempMemoryStream).ReadToEndAsync();
            tempMemoryStream.Seek(0, SeekOrigin.Begin);

            if (context.Response.StatusCode >= 200 && context.Response.StatusCode < 300)
            {
                _logger.LogInformation("Response sent: {StatusCode} TraceId: {TraceId}", context.Response.StatusCode, traceId);
                context.Response.Body = originalBodyStream;
                await context.Response.WriteAsync(bodyText);
            }
            else
            {
                _logger.LogWarning("Error response: {StatusCode} TraceId: {TraceId} Details: {Details}", context.Response.StatusCode, traceId, bodyText);
                context.Response.ContentType = "application/json";
                context.Response.Body = originalBodyStream;

                var errorResponse = new
                {
                    success = false,
                    statusCode = context.Response.StatusCode,
                    error = GetErrorTitle(context.Response.StatusCode),
                    details = string.IsNullOrWhiteSpace(bodyText) ? null : new[] { bodyText },
                    traceId = traceId
                };

                await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
            }
        }

        private static string GetErrorTitle(int statusCode) => statusCode switch
        {
            400 => "Bad Request",
            401 => "Unauthorized",
            403 => "Forbidden",
            404 => "Not Found",
            500 => "Internal Server Error",
            _ => "Error"
        };
    }
}
