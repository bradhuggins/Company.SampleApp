#region Using Statements
using Company.SampleApp.Domain.Client.Dtos;
using Company.SampleApp.Domain.Client.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
#endregion

namespace Company.SampleApp.Tests.Domain.Client.Messages
{
    [TestClass]
    public class ResourceGetWithCriteriaResponseTests
    {
        [TestMethod]
        public void HasErrorMessageFalseTest()
        {
            // Arrange
			ResourceGetWithCriteriaResponse target = new ResourceGetWithCriteriaResponse();

            // Act
			string expected = target.ErrorMessage;
			
            // Assert
			Assert.IsNull(expected);
			Assert.IsFalse(target.HasError);
        }

		[TestMethod]
        public void HasErrorMessageTrueTest()
        {
            // Arrange
			ResourceGetWithCriteriaResponse target = new ResourceGetWithCriteriaResponse();
			target.ErrorMessage = "error";

            // Act
			string expected = target.ErrorMessage;
			
            // Assert
			Assert.IsNotNull(expected);
			Assert.IsTrue(target.HasError);
        }
        
		[TestMethod]
        public void ResultsTest()
        {
            // Arrange
			ResourceGetWithCriteriaResponse target = new ResourceGetWithCriteriaResponse();
			target.Results = new List<Resource>();

            // Act
			var expected = target.Results;
			
            // Assert
			Assert.IsNotNull(expected);
			Assert.IsTrue(expected.Count == 0);
        }

		[TestMethod]
        public void TotalCountTest()
        {
            // Arrange
			ResourceGetWithCriteriaResponse target = new ResourceGetWithCriteriaResponse();
			target.TotalCount = 1;

            // Act
			var expected = target.TotalCount;
			
            // Assert
			Assert.IsTrue(expected == 1);
        }


    }
}
