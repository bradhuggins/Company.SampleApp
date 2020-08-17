#region Using Statements
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Company.SampleApp.Domain.Client.Dtos;
using Company.SampleApp.Domain.Client.Messages;
using System.Collections.Generic;
#endregion

namespace Company.SampleApp.Tests.Domain.Client.Messages
{
    [TestClass]
    public class ChildResourceGetWithCriteriaResponseTests
    {
        [TestMethod]
        public void HasErrorMessageFalseTest()
        {
            // Arrange
			ChildResourceGetWithCriteriaResponse target = new ChildResourceGetWithCriteriaResponse();

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
			ChildResourceGetWithCriteriaResponse target = new ChildResourceGetWithCriteriaResponse();
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
			ChildResourceGetWithCriteriaResponse target = new ChildResourceGetWithCriteriaResponse();
			target.Results = new List<ChildResource>();

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
			ChildResourceGetWithCriteriaResponse target = new ChildResourceGetWithCriteriaResponse();
			target.TotalCount = 1;

            // Act
			var expected = target.TotalCount;
			
            // Assert
			Assert.IsTrue(expected == 1);
        }


    }
}
