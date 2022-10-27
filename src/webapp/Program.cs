using Microsoft.OpenApi.Models;
using webapp;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json");

builder.Services.Configure<SettingsOptions>(
    builder.Configuration.GetSection(SettingsOptions.Key));

builder.Services.Configure<AuthOptions>(
    builder.Configuration.GetSection(AuthOptions.Key));

// Add services to the container.
builder.Services
        .AddControllers()
        .Services
        .AddEndpointsApiExplorer()
        .ConfigureSwagger("Bookclub App")
        // .AddSwaggerGen(x => {
        // })
        .ConfigureHealthChecks()
        .ConfigureAuthentication(builder.Configuration);

var app = builder.Build();
app.UseCustomFixForHttps();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bookclub App"));
}
else
{
    app.UseExceptionHandler("/error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.RegisterBaseRoutes();
app.MapHealthChecks();
app.MapFallbackToFile("/index.html");

app.Run();
