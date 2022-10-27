using Microsoft.AspNetCore.Mvc;
using webapp.Features.Settings.GetSettings;

namespace webapp
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