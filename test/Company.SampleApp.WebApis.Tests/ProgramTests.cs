#region Using Statements
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#endregion

namespace Company.SampleApp.WebApis.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void CreateHostBuilderTest()
        {
            // Arrange
            string[] args = new string[0];
            string error = null;

            // Act
            try
            {
                Program.CreateHostBuilder(args);
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
