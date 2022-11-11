using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;
using Lanre.Module.Library;
using Lanre.Module.Poll;
using Lanre.Infrastructure.Contexts;
using Lanre.Web;

var builder = WebApplication.CreateBuilder(args);

builder
    .Configuration
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", false)
    .AddEnvironmentVariables()
    ;

builder.WebHost.ConfigureKestrel(c =>
{
    c.Limits.KeepAliveTimeout = TimeSpan.FromSeconds(40);
});

builder.Services.Configure<SettingsOptions>(
    builder.Configuration.GetSection(SettingsOptions.Key));

builder.Services.Configure<AuthOptions>(
    builder.Configuration.GetSection(AuthOptions.Key));

// Add services to the container.
builder.Services
        .AddApplicationInsightsTelemetry()
        .AddControllers()
        .Services
        .AddEndpointsApiExplorer()
        .ConfigureSwagger("Bookclub App")
        .ConfigureHealthChecks()
        .ConfigureAuthentication(builder.Configuration)
        .ConfigureLibrary(builder.Configuration)
        .ConfigurePoll(builder.Configuration)
        //.AddScoped<IActionContextAccessor, ActionContextAccessor>()
        .AddHttpContextAccessor()
        ;

var app = builder.Build();
var scope = app.Services.CreateScope();
var libraryContext = scope.ServiceProvider.GetService<Lanre.Module.Library.Infrastructure.Database.LibraryContext>();
var pollContext = scope.ServiceProvider.GetService<Lanre.Module.Poll.Infrastructure.Database.PollContext>();
var sqlOptions = scope.ServiceProvider.GetService<IOptions<SqlOptions>>();
if (app.Environment.IsDevelopment())
{
    ContextInitialize.InitializeDb(sqlOptions.Value, libraryContext).Wait();
    ContextInitialize.InitializeDb(sqlOptions.Value, pollContext).Wait();
}
scope.Dispose();


app.UseCustomFixForHttps();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bookclub App"));

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.RegisterBaseRoutes();
app.RegisterBookRoutes();
app.RegisterPollRoutes();

app.MapHealthChecks();
app.MapFallbackToFile("/index.html");

app.Run();