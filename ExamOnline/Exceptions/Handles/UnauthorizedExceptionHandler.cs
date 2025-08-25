using ExceptionHandleDemo.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ExamOnline.Exceptions.Handles
{
    public class UnauthorizedExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is UnauthorizedException unauthEx)
            {
                httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status401Unauthorized,
                    Title = "Unauthorized",
                    Detail = unauthEx.Message
                };

                await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
                return true;
            }
            return false;
        }
    }
}
