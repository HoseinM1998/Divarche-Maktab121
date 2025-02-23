namespace Divarcheh.Endpoints.RazorPages.Middelware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                System.IO.File.WriteAllText("C:/Test/Error.txt", e.Message);
            }
            finally
            {
                await _next(context);
            }
        }
    }
}
