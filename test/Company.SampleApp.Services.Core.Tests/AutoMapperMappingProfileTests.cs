#region Using Statements
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#endregion

namespace Company.SampleApp.Services.Core.Tests
{
    [TestClass]
    public class AutoMapperMappingProfileTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            // Arrange
            string error = null;

            // Act
            try
            {
                new AutoMapperMappingProfile();
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
