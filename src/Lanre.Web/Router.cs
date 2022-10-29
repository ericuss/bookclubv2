using Microsoft.AspNetCore.Mvc;
using Lanre.Web.Features.Settings.GetSettings;

namespace Lanre.Web
{
    public static class Router
    {
        public static void RegisterBaseRoutes(this WebApplication app)
        {
            app.MapGet("/api/settings", GetSettingsEndpoint.Handle);
            app.MapGet("/api/settings/auth", GetAuthEndpoint.Handle).RequireAuthorization();
        }
    }
}