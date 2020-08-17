#region Using Statements
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endregion

namespace Company.SampleApp.Services.Core.Tests
{
    [TestClass]
    public abstract class ServiceTestsBase
    {
        protected IMapper _mapper;

        [TestInitialize]
        public void Initalize()
        {
            IServiceCollection services = new ServiceCollection();            
            services.AddAutoMapper(typeof(MappingProfile));
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            _mapper = serviceProvider.GetService<IMapper>();
        }


    }
    
}
