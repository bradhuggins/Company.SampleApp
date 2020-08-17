#region Using Statements
using Company.SampleApp.WebApis.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endregion

namespace Company.SampleApp.WebApis.Tests.Models
{
    [TestClass]
    public class ErrorViewModelTests
    {
        [TestMethod]
        public void ShowRequestIdFalseTest()
        {
            // Arrange
            ErrorViewModel target = new ErrorViewModel();

            // Act
            var actual = target.ShowRequestId;

            // Assert
            Assert.IsFalse(actual);
        }

		[TestMethod]
        public void ShowRequestIdTrueTest()
        {
            // Arrange
            ErrorViewModel target = new ErrorViewModel();
			target.RequestId = "123";

            // Act
            var actual = target.ShowRequestId;

            // Assert
            Assert.IsTrue(actual);
        }

    }
}
