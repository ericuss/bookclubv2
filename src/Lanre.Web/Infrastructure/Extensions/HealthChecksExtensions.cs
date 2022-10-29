using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class HealthChecksExtensions
    {
        public static IServiceCollection ConfigureHealthChecks(this IServiceCollection services)
        {
            return services
                    .AddHealthChecks()
                    .Services;
        }
        public static IEndpointConventionBuilder MapHealthChecks(this IEndpointRouteBuilder endpoint)
        {
            return endpoint
                    .MapHealthChecks("healthz")
                    ;
        }
    }
}