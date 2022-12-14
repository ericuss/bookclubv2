using Lanre.Module.Library.Infrastructure.Database;
using Lanre.Infrastructure.Contexts;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Samples.Services;
using Lanre.Module.Library.Application.Books;

namespace Lanre.Module.Library;
public static class Configure
{
    private const string SqlSectionKey = "Sql";
    public static IServiceCollection ConfigureLibrary(this IServiceCollection services, IConfiguration configuration)
    {
        var sqlOptions = configuration.GetSection(SqlSectionKey).Get<SqlOptions>();
        return services
                .RegisterDB(sqlOptions)
                .Configure<SqlOptions>(configuration.GetSection(SqlSectionKey))
                .AddSingleton<IBookAccumulatorQueue, BookAccumulatorQueue>()
                .AddSingleton<ImportBookFeature>()
                .AddHostedService<AccumulatorBackgroundService>();
        ;
    }

    private static IServiceCollection RegisterDB(this IServiceCollection services, SqlOptions sqlOptions)
    {
        services.AddDbContext<LibraryContext>(o => o.UseSqlServer(sqlOptions.ConnectionString, x =>
            x.EnableRetryOnFailure(5, TimeSpan.FromSeconds(2000), null)
        ), ServiceLifetime.Transient);

        return services;
    }
}
