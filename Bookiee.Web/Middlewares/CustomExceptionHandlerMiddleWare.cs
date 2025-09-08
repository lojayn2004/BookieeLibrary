using Domain.Exceptions.General;
using Shared.ErrorModels;
using System.Net;
using System.Text.Json;

namespace Bookiee.Web.Middlewares
{
    public class CustomExceptionHandlerMiddleWare
    {
        private RequestDelegate _next;
        private ILogger<CustomExceptionHandlerMiddleWare> _logger;


        public CustomExceptionHandlerMiddleWare(RequestDelegate next, ILogger<CustomExceptionHandlerMiddleWare> logger)
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
                _logger.LogError($"Something Went Wrong : {ex.Message}");
                await HandleException(context, ex);
            }

        }

        private async Task HandleException(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            context.Response.StatusCode = ex switch
            {
                NotFoundException => (int) HttpStatusCode.NotFound,
                _ => (int) HttpStatusCode.InternalServerError
            };

            ErrorResponse error = new ErrorResponse()
            {
                ErrorMessage = ex.Message,
                StatusCode = context.Response.StatusCode
            };

            await context.Response.WriteAsJsonAsync(JsonSerializer.Serialize(error));
        }
    }
}
