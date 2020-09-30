#region Using Statements
using Company.SampleApp.Domain.Client.Enumerations;
using Company.SampleApp.Domain.Client.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endregion

namespace Company.SampleApp.Tests.Domain.Client.Messages
{
    [TestClass]
    public class ChildResourceSearchCriteriaTests
    {
        [TestMethod]
        public void UpdateCriteriaTest()
        {
            // Arrange
            ChildResourceSearchCriteria target = new ChildResourceSearchCriteria();

            // Act
            target.UpdateCriteria("Name", 1);
			
            // Assert
			Assert.IsNotNull(target);
        }

		[TestMethod]
        public void UpdateCriteriaDirectionTest()
        {
            // Arrange
            ChildResourceSearchCriteria target = new ChildResourceSearchCriteria();
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
            ChildResourceSearchCriteria target = new ChildResourceSearchCriteria();

            // Act
            target.UpdateCriteria("Name", -1);

            // Assert
            Assert.IsNotNull(target);
        }

        [TestMethod]
        public void UpdateCriteriaInvalidPageSizeTest()
        {
            // Arrange
            ChildResourceSearchCriteria target = new ChildResourceSearchCriteria();
            target.PageSize = 2;

            // Act
            target.UpdateCriteria("Name", 1);

            // Assert
            Assert.IsNotNull(target);
        }

    }
}
