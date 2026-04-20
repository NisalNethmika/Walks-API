namespace WebApp1.Middlewares
{
    public class ExceptionHandlerMiddleware
    {

        private readonly ILogger<ExceptionHandlerMiddleware> logger;
        private readonly RequestDelegate next;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An unhandled exception occurred.");
                httpContext.Response.StatusCode = 500;
                httpContext.Response.ContentType = "application/json";

                var error = new
                {
                    Error = $"An unhandled exception occurred. Internal server error. {ex.Message}"
                };

                await httpContext.Response.WriteAsJsonAsync(error);
            }
        }
    }
}
