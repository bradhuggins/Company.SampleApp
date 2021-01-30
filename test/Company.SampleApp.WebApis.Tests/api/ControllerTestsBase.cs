#region Using Statements
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endregion

namespace Company.SampleApp.WebApis.Tests.api
{
    [TestClass]
    public abstract class ControllerTestsBase
    {
        protected IConfiguration _configuration;
        //protected IMapper _mapper;

        [TestInitialize]
        public void Initalize()
        {
            IServiceCollection services = new ServiceCollection();

            // Configuration
            _configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", true, true)
               .Build();
            services.AddSingleton(_configuration);

            //// AutoMapper
            //services.AddAutoMapper(typeof(MappingProfile));

            ServiceProvider serviceProvider = services.BuildServiceProvider();
            //_mapper = serviceProvider.GetService<IMapper>();
        }
    }
}
