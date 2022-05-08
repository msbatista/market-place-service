using Microsoft.AspNetCore.Mvc.ApiExplorer;
using WebApi.Modules.Extensions;
using WebApi.Modules.Extensions.Swagger;

namespace WebApi;

/// <summary>
/// Startup.
/// </summary>
public class Startup
{
    /// <summary>
    /// Get configuration.
    /// </summary>
    /// <value></value>
    public IConfiguration Configuration {get;}

    /// <summary>
    /// Get web host environment.
    /// </summary>
    public IWebHostEnvironment Environment;


    /// <summary>
    /// Initializes an instance of Startup.
    /// </summary>
    /// <param name="configuration"></param>
    /// <param name="environment"></param>
    public Startup(IConfiguration configuration, IWebHostEnvironment environment)
    {
        this.Configuration = configuration;
        this.Environment = environment;
    }

    /// <summary>
    /// This method gets called by the runtime. Use it to add services to the container.
    /// </summary>
    /// <param name="services"></param>
    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddCustomControllers()
            .AddApiVersionStrategy()
            .AddCustomDbContext(Configuration)
            .AddUseCases()
            .AddSwagger();
    }

    /// <summary>
    /// Configures HTTP request pipeline.
    /// </summary>
    /// <param name="app"></param>
    /// <param name="env"></param>
    /// <param name="provider"></param>
    public void Configure(
        IApplicationBuilder app,
        IWebHostEnvironment env,
        IApiVersionDescriptionProvider provider) 
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection()
            .UseRouting()
            .UseVersionedSwagger(provider, this.Configuration, env)
            .UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
    }
}
