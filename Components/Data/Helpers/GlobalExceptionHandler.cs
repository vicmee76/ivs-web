using ivs.Domain.Constants;

namespace ivs_ui.Components.Data.Helpers
{
    public class GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<GlobalExceptionHandler> _logger = logger;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Exception occurred: {Message}", exception);

                new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong, please try agian later"
                    }
                };
            }
        }
       
    }
}
