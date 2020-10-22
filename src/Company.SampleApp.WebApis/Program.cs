#region Using Statements
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;
#endregion

namespace Company.SampleApp.WebApis
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)

			    // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration 
                //.ConfigureAppConfiguration((hostingContext, config) =>
                //{
                    //config.SetBasePath(Directory.GetCurrentDirectory());

                    //config.AddIniFile("custom_config.ini", optional: true, reloadOnChange: true);

                    //config.AddXmlFile("custom_config.xml", optional: true, reloadOnChange: true);

                    //config.AddJsonFile("custom_config.json", optional: false, reloadOnChange: false);

                    //config.AddInMemoryCollection(_dict);

                    // Call AddEnvironmentVariables last if you need to allow environment
                    // variables to override values from other providers.
                    //config.AddEnvironmentVariables(prefix: "APPENV_");

                    // Call AddCommandLine last to allow arguments to override other configuration.
                    //config.AddCommandLine(args);
                //})

                // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging
                .ConfigureLogging((hostingContext, logging) =>
                {
                    // Default providers and default order
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    //logging.AddConsole();
                    logging.AddDebug();
                    //logging.AddEventSourceLogger();

                    //// Additional providers
                    //logging.AddAzureWebAppDiagnostics();
                    //logging.AddApplicationInsights();
                })

                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
