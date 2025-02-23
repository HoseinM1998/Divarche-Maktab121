using Divarcheh.Domain.Core.Entities.Configs;

namespace Divarcheh.Endpoints.RazorPages.Middelware
{

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseApiKeyValidation(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiKeyMiddleware>();
        }
    }

    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly SiteSettings _siteSettings;
        private static readonly List<string> WhitelistedActions = new()
        {
            "/admin",
        };

        public ApiKeyMiddleware(RequestDelegate next, SiteSettings siteSettings)
        {
            _next = next;
            _siteSettings = siteSettings;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.ToString();

            if (WhitelistedActions.Any(x => path.ToUpper().Contains(x.ToUpper())) && path.ToUpper() != "/admin/AccessDenied".ToUpper())
            {
                if (context.Request.Cookies.TryGetValue("ApiKey", out var apiKey) && !string.IsNullOrEmpty(apiKey))
                {
                    if (apiKey == _siteSettings.ApiKey)
                    {
                        await _next(context);
                    }
                    else
                    {
                         context.Response.Redirect("AccessDenied");
                    }
                }
                else
                {
                    context.Response.Redirect("AccessDenied");
                }
            }
            await _next(context);
        }
    }
}
