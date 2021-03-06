#region Using Statements
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Company.SampleApp.Data.Ef.Tests;
using System;
#endregion

namespace Company.SampleApp.Repositories.Ef.Tests
{
    [TestClass]
    public abstract class RepositoryTestsBase
    {
        internal MockDbContext _context;
        internal NullDbContext _nullContext;

        [TestInitialize]
        public void Initalize()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddDbContext<MockDbContext>(
                options => options.UseInMemoryDatabase("TestsInMemoryDb-" + Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
            );

            services.AddDbContext<NullDbContext>(
                options => options.UseInMemoryDatabase("NullTestsInMemoryDb-" + Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
            );

            ServiceProvider serviceProvider = services.BuildServiceProvider();
            _context = serviceProvider.GetService<MockDbContext>();
            _nullContext = serviceProvider.GetService<NullDbContext>();

        }


    }
}
