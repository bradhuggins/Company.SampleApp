#region Using Statements
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#endregion

namespace Company.SampleApp.WebApis.Tests
{
    [TestClass]
    public class SwaggerServiceExtensionsTests
    {
        public IConfiguration Configuration { get; set; }
        
        [TestMethod]
        public void AddSwaggerDocumentationTest()
        {
            // Arrange
            IServiceCollection services = new ServiceCollection();
            string error = null;

            // Act
            try
            {
                SwaggerServiceExtensions.AddSwaggerDocumentation(services);
            }
            catch (Exception ex)
            {
                error = ex.ToString();
            }

            // Assert
            Assert.IsNull(error);
        }

        [TestMethod]
        public void UseSwaggerDocumentationTest()
        {
            // Arrange
            IServiceCollection services = new ServiceCollection();
            SwaggerServiceExtensions.AddSwaggerDocumentation(services);
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            IApplicationBuilder app = new Microsoft.AspNetCore.Builder.ApplicationBuilder(serviceProvider);
            string error = null;

            // Act
            try
            {
                SwaggerServiceExtensions.UseSwaggerDocumentation(app);
            }
            catch (Exception ex)
            {
                error = ex.ToString();
            }

            // Assert
            Assert.IsNull(error);
        }


    }
}
