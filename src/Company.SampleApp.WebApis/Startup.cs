#region Using Statements
using AutoMapper;
using Company.SampleApp.Data.Ef;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using System.Diagnostics.CodeAnalysis;
#endregion

namespace Company.SampleApp.WebApis
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
		public static readonly LoggerFactory DbDebugLoggerFactory = new LoggerFactory(new[] { new DebugLoggerProvider() });

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
		    // https://docs.microsoft.com/en-us/azure/azure-monitor/app/asp-net-core
            // The following line enables Application Insights telemetry collection.
            //services.AddApplicationInsightsTelemetry();

            services.AddDbContext<AppDbContext>(
                options => options
                .UseLoggerFactory(DbDebugLoggerFactory) // Warning: Do not create a new ILoggerFactory instance each time
                // https://docs.microsoft.com/en-us/ef/core/miscellaneous/logging
                .UseSqlServer(Configuration.GetConnectionString("PrimaryDatabase"))
				//.AddInterceptors(new WithNoLockInterceptor())
            );

		// Repositories
			services.AddTransient<Repositories.Interfaces.IChildResourceRepository, Repositories.Ef.ChildResourceRepository>();
			services.AddTransient<Repositories.Interfaces.IResourceRepository, Repositories.Ef.ResourceRepository>();
		// Services
			services.AddTransient<Services.Interfaces.IChildResourceService, Services.Core.ChildResourceService>();
			services.AddTransient<Services.Interfaces.IResourceService, Services.Core.ResourceService>();


			services.AddAutoMapper(typeof(Services.Core.AutoMapperMappingProfile));

		services.AddControllers()
                .AddNewtonsoftJson(options =>
               {
                   options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                   options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.None;
               })
                .AddJsonOptions(options => {
                options.JsonSerializerOptions.IgnoreNullValues = true;
                });

            services.AddSwaggerDocumentation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                // app.UseHsts();
            }

            app.UseHttpsRedirection();



            app.UseRouting();

            app.UseAuthorization();

		app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            if (!env.IsProduction())
            {
                app.UseSwaggerDocumentation();
            }

        }
    }
}
