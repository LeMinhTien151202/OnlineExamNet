
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionHandleDemo.Exceptions.Handles
{
    public class NotFoundExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<NotFoundExceptionHandler> _logger;

        public NotFoundExceptionHandler(ILogger<NotFoundExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is NotFoundException notFoundEx)
            {
                _logger.LogWarning(exception, "Resource not found: {Message}", notFoundEx.Message);

                httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status404NotFound,
                    Title = "Not Found",
                    Detail = notFoundEx.Message
                };

                await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
                return true; // ✅ Đã handle rồi
            }

            return false; // Cho handler khác xử lý
        }
    }
}
