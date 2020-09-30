#region Using Statements
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endregion

namespace Company.SampleApp.WebApis.Tests.api
{
    [TestClass]
    public abstract class ControllerTestsBase
    {
        //protected IMapper _mapper;

        [TestInitialize]
        public void Initalize()
        {
            IServiceCollection services = new ServiceCollection();            
            //services.AddAutoMapper(typeof(MappingProfile));
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            //_mapper = serviceProvider.GetService<IMapper>();

        }
    }
}
