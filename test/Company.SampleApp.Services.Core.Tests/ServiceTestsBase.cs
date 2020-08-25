#region Using Statements
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endregion

namespace Company.SampleApp.Services.Core.Tests
{
    [TestClass]
    public abstract class ServiceTestsBase
    {
        protected IMapper _mapper;
        public IConfiguration Configuration { get; set; }

        [TestInitialize]
        public void Initalize()
        {
            this.Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            IServiceCollection services = new ServiceCollection();            
            services.AddAutoMapper(typeof(MappingProfile));
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            _mapper = serviceProvider.GetService<IMapper>();
        }


    }
    
}
