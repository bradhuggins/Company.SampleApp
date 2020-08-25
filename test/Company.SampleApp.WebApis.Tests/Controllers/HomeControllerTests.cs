#region Using Statements
using Company.SampleApp.WebApis.Controllers;
using Company.SampleApp.WebApis.Tests.ServiceMocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
#endregion

namespace Company.SampleApp.WebApis.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void IndexTest()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }


    }
}
