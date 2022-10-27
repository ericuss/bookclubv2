using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services, string title)
        {
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = title, Version = "v1" });
                c.CustomSchemaIds(x => string.Join(null, x.FullName.Split('.').Skip(1).ToList()));
                // c.TagActionsBy(api =>
                // {
                //     if (api.GroupName != null)
                //     {
                //         return new[] { api.GroupName };
                //     }

                //     try
                //     {
                //         return new[] {
                //             ((ControllerActionDescriptor)api.ActionDescriptor).ControllerTypeInfo.FullName.Split("Features.")[1].Split(".")[0]
                //         };
                //     }
                //     catch (Exception _) { }

                //     if (api.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
                //     {
                //         return new[] { controllerActionDescriptor.ControllerName };
                //     }

                //     throw new InvalidOperationException("Unable to determine tag for endpoint.");
                // });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter ‘Bearer’ [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            Array.Empty<string>()
                        }
                });
            });
        }
        public static IServiceCollection ConfigureSwaggerWithoutAuth(this IServiceCollection services, string title)
        {
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = title, Version = "v1" });
                c.CustomSchemaIds(x => string.Join(null, x.FullName.Split('.').SkipWhile(x => x != "Features").Skip(1).ToList()));
            });
        }
    }
}