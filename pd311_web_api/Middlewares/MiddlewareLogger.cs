namespace pd311_web_api.Middlewares
{
    public class MiddlewareLogger
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MiddlewareLogger> _logger;

        public MiddlewareLogger(RequestDelegate next, ILogger<MiddlewareLogger> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogWarning($"{context.Request.Path}: {context.Request.Method}, Server: {context.Request.Headers.Server}");

            await _next(context);

            _logger.LogWarning($"RESPONSE - {DateTime.Now.Second}:{DateTime.Now.Millisecond}:{DateTime.Now.Microsecond}: ");
        }
    }
}
