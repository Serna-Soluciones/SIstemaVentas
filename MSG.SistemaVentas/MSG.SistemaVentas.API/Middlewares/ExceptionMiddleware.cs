using System.Diagnostics;
using System.Net;
using System.Reflection.Metadata;
using System.Text.Json;

namespace MSG.SistemaVentas.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _environment;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsnyc(context, ex);
            }
        }

        private async Task HandleExceptionAsnyc(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = _environment.IsDevelopment() ?
                new
                {
                    context.Response.StatusCode,
                    Message = exception.Message,
                    StackTrace = exception.StackTrace
                } :
                new { context.Response.StatusCode, Message = "Internal Server Error", StackTrace = exception.StackTrace };
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            await context.Response.WriteAsync(JsonSerializer.Serialize(response, options));
        }
    }
}
