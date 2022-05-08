using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApi.Modules.Extensions.Swagger;

/// <summary>
/// Configure swagger service.
/// </summary>
public static class SwaggerExtensions
{
    private static string XmlCommentsFilePath
    {
        get
        {
            string basePath = PlatformServices.Default.Application.ApplicationBasePath;
            string fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
            return Path.Combine(basePath, fileName);
        }
    }

    /// <summary>
    /// Add Swagger Configuration dependencies.
    /// </summary>
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services
            .AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>()
            .AddSwaggerGen(
                c =>
                {
                    c.IncludeXmlComments(XmlCommentsFilePath);
                });
        return services;
    }

    /// <summary>
    /// Add Swagger dependencies.
    /// </summary>
    public static IApplicationBuilder UseVersionedSwagger(
        this IApplicationBuilder app,
        IApiVersionDescriptionProvider provider,
        IConfiguration configuration,
        IWebHostEnvironment env)
    {
        app.UseSwagger();
        app.UseSwaggerUI(
            options =>
            {
                foreach (ApiVersionDescription description in provider.ApiVersionDescriptions)
                {
                    string swaggerEndpoint;

                    string basePath = configuration["ASPNETCORE_BASEPATH"];

                    if (!string.IsNullOrEmpty(basePath))
                    {
                        swaggerEndpoint = $"{basePath}/swagger/{description.GroupName}/swagger.json";
                    }
                    else
                    {
                        swaggerEndpoint = $"/swagger/{description.GroupName}/swagger.json";
                    }

                    options.SwaggerEndpoint(swaggerEndpoint, description.GroupName.ToUpperInvariant());
                }
            });

        return app;
    }
}
