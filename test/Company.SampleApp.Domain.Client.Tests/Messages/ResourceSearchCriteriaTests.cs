#region Using Statements
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Company.SampleApp.Domain.Client.Enumerations;
using Company.SampleApp.Domain.Client.Messages;
#endregion

namespace Company.SampleApp.Tests.Domain.Client.Messages
{
    [TestClass]
    public class ResourceSearchCriteriaTests
    {
        [TestMethod]
        public void UpdateCriteriaTest()
        {
            // Arrange
            ResourceSearchCriteria target = new ResourceSearchCriteria();

            // Act
            target.UpdateCriteria("Name", 1);
			
            // Assert
			Assert.IsNotNull(target);
        }

		[TestMethod]
        public void UpdateCriteriaDirectionTest()
        {
            // Arrange
            ResourceSearchCriteria target = new ResourceSearchCriteria();
            target.SortDirection = SortDirection.Descending;

            // Act
            target.UpdateCriteria("Name", 1);

            // Assert
            Assert.IsNotNull(target);
        }

        [TestMethod]
        public void UpdateCriteriaInvalidPageNumberTest()
        {
            // Arrange
            ResourceSearchCriteria target = new ResourceSearchCriteria();

            // Act
            target.UpdateCriteria("Name", -1);

            // Assert
            Assert.IsNotNull(target);
        }

        [TestMethod]
        public void UpdateCriteriaInvalidPageSizeTest()
        {
            // Arrange
            ResourceSearchCriteria target = new ResourceSearchCriteria();
            target.PageSize = 2;

            // Act
            target.UpdateCriteria("Name", 1);

            // Assert
            Assert.IsNotNull(target);
        }

    }
}
