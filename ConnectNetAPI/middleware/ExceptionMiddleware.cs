using ConnectNet.Errors;
using System.Net;
using System.Text.Json;

namespace ConnectNet.middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;
        private readonly IHostEnvironment hostEnvironment;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment hostEnvironment)
        {
            this.next = next;
            this.logger = logger;
            this.hostEnvironment = hostEnvironment;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                var response = hostEnvironment.IsDevelopment() ? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace.ToString()) :
                    new ApiException(context.Response.StatusCode, ex.Message, "Internal Server Error");
                var option = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                var Json = JsonSerializer.Serialize(response, option);

                await context.Response.WriteAsync(Json);
            }
        }
    }
}
