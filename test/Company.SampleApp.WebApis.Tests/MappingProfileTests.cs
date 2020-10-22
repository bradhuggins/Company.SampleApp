#region Using Statements
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#endregion

namespace Company.SampleApp.WebApis.Tests
{
    [TestClass]
    public class MappingProfileTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            // Arrange
            string error = null;

            // Act
            try
            {
                new MappingProfile();
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
