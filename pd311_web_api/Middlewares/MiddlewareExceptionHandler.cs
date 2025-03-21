using pd311_web_api.BLL.Services;

namespace pd311_web_api.Middlewares
{
    public class MiddlewareExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MiddlewareExceptionHandler> _logger;

        public MiddlewareExceptionHandler(RequestDelegate next, ILogger<MiddlewareExceptionHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                string error = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                var response = new ServiceResponse(message: error);

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
