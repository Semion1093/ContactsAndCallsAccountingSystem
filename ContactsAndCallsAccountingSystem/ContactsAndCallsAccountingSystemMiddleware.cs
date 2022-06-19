using ContactsAndCallsAccountingSystem.BLL.Exeptions;
using System.Net;
using System.Text.Json;

namespace ContactsAndCallsAccountingSystem.API
{
    public class ContactsAndCallsAccountingSystemMiddleware
    {
        private readonly RequestDelegate _next;

        public ContactsAndCallsAccountingSystemMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (EntityNotFoundException ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.NotFound, ex.Message);
            }
            catch (Microsoft.Data.SqlClient.SqlException)
            {
                await HandleExceptionAsync(context, HttpStatusCode.ServiceUnavailable, "Сервер недоступен");
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.BadRequest, ex.Message);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, HttpStatusCode code, string message)
        {
            var result = JsonSerializer.Serialize(new { error = message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            await context.Response.WriteAsync(result);
        }
    }
}
