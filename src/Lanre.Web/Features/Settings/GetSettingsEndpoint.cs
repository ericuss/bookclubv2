using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Lanre.Web.Features.Settings.GetSettings;


public static class GetSettingsEndpoint
{
    public static IResult Handle(
        [FromServices] IOptions<SettingsOptions> settings,
        [FromServices] IOptions<AuthOptions> auth
    )
    {
        return Results.Ok(new {
            settings = settings.Value,
            auth = auth.Value,
        });
    }
}