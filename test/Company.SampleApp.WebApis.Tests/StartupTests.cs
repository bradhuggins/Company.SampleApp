#region Using Statements
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
#endregion

namespace Company.SampleApp.WebApis.Tests
{
    [TestClass]
    public class StartupTests
    {
        public IConfiguration Configuration { get; set; }

        [TestMethod]
        public void ConstructorTest()
        {
            // Arrange
            this.Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            string error = null;

            // Act
            try
            {
                new Startup(this.Configuration);
            }
            catch (Exception ex)
            {
                error = ex.ToString();
            }

            // Assert
            Assert.IsNull(error);
        }

        //[TestMethod]
        //public void ConfigureTest()
        //{
        //    // Arrange
        //    IServiceCollection services = new ServiceCollection();
        //    IApplicationBuilder app;
        //    IWebHostEnvironment env;
        //    string error = null;

        //    // Act
        //    try
        //    {
        //        new Startup(this.Configuration).Configure(app, env);
        //    }
        //    catch (Exception ex)
        //    {
        //        error = ex.ToString();
        //    }

        //    // Assert
        //    Assert.IsNull(error);
        //}




    }
}
