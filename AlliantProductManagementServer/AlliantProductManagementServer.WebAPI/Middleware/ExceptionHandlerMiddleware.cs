using AlliantProductManagementServer.Domain.Exceptions;
using System.Diagnostics;
using System.Net;

namespace AlliantProductManagementServer.WebAPI.Middleware
{
    public class ExceptionHandlerMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DomainException ex)
            {
                await BuildResponse(context, ex.ErrorCode, "Error", ex.Message);
            }
            catch (Exception ex)
            {
                await BuildResponse(context, (int)HttpStatusCode.InternalServerError, "title", ex.Message);
            }
        }
        private static async Task BuildResponse(HttpContext context, int code, string tittle, string errorMessage, object? details = null)
        {
            context.Response.ContentType = "application/problem+json";
            var stream = context.Response.Body;
            var traceId = Activity.Current?.Id ?? context.TraceIdentifier;

            context.Response.StatusCode = (int)code;

            await System.Text.Json.JsonSerializer.SerializeAsync(stream,
                new { status = code, message = errorMessage, title = tittle, traceId, details });

        }
    }
}
