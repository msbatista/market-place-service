namespace WebApi
{
    /// <summary>
    /// Entry point.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main.
        /// </summary>
        /// <param name="args"></param>
        public static Task Main(string[] args) =>
            CreateHostBuilder(args)
            .Build()
            .RunAsync();

        /// <summary>
        /// CreateHostBuilder.
        /// </summary>
        /// <param name="args"></param>
        /// <returns>IHostBuilder</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.CaptureStartupErrors(true);

                    webBuilder.ConfigureLogging(logging =>
                    {
                        logging.ClearProviders()
                        .AddConsole()
                        .AddJsonConsole()
                        .AddApplicationInsights()
                        .SetMinimumLevel(LogLevel.Information);

                    });

                    webBuilder.UseStartup<Startup>();
                });
    }
}