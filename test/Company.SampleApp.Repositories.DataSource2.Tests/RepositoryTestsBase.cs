#region Using Statements
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Extensions.Configuration;
#endregion

namespace Company.SampleApp.Repositories.DataSource2.Tests
{
    [TestClass]
    public abstract class RepositoryTestsBase
    {       
        public IConfiguration Configuration { get; set; }

        [TestInitialize]
        public void Initalize()
        {
            this.Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            //IServiceCollection services = new ServiceCollection();
            //ServiceProvider serviceProvider = services.BuildServiceProvider();

        }

    }
}
