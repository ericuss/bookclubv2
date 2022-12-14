using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Lanre.Web.Features.Settings.GetSettings;


public static class GetAuthEndpoint
{
    public static IResult Handle([FromServices] IOptions<SettingsOptions> options)
    {
        return Results.Ok(options.Value);
    }
}