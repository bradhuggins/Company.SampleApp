#region Using Statements
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Company.SampleApp.Data.Ef;
using System;
#endregion

namespace Company.SampleApp.DatabaseRebuild
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("STARTING...");

            try
            {
                IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

                IServiceCollection services = new ServiceCollection();

                services.AddDbContext<AppDbContext>(
                    options => options
                    .UseSqlServer(configuration.GetConnectionString("PrimaryDatabase"))
                    .EnableSensitiveDataLogging()
                );

                ServiceProvider serviceProvider = services.BuildServiceProvider();
                using (var context = serviceProvider.GetService<AppDbContext>())
                {
                    Console.WriteLine("Dropping and recreating database");
                    context.CreateDatabase();

                    Console.WriteLine("Seeding data");
                    new SeedData(context);
                    
                }

                Console.WriteLine("COMPLETE...");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
