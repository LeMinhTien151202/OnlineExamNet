using ExamOnline.Exceptions;
using System.Net;
using System.Text.Json;

namespace ExamOnline.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception occurred");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode status;
            string message = ex.Message;

            switch (ex)
            {
                case BadRequestException:
                    status = HttpStatusCode.BadRequest;
                    break;
                case UnauthorizedException:
                    status = HttpStatusCode.Unauthorized;
                    break;
                //case ForbiddenException:
                //    status = HttpStatusCode.Forbidden;
                //    break;
                case NotFoundException:
                    status = HttpStatusCode.NotFound;
                    break;
                default:
                    status = HttpStatusCode.InternalServerError;
                    message = "An unexpected error occurred.";
                    break;
            }

            var response = new
            {
                status = (int)status,
                error = status.ToString(),
                message,
                timestamp = DateTime.UtcNow
            };

            var payload = JsonSerializer.Serialize(response);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            return context.Response.WriteAsync(payload);
        }
    }

    // Extension ?? d? dùng trong Program.cs
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}