#region Using Statements
using Company.SampleApp.Domain.Client.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
#endregion

namespace Company.SampleApp.Tests.Domain.Client.Messages
{
    [TestClass]
    public class PagingListTests
    {
        [TestMethod]
        public void NoParameterConstructorTest()
        {
            // Arrange

            // Act
            PagingList<string> target = new PagingList<string>();

            // Assert

        }

        [TestMethod]
        public void CollectionConstructorTest()
        {
            // Arrange
            List<string> expected = new List<string>()
            {
                "foo",
                "bar"
            };
            
            // Act
            PagingList<string> target = new PagingList<string>(expected);

            // Assert

        }

        [TestMethod]
        public void TotalCountTest()
        {
            // Arrange
            List<string> expected = new List<string>()
            {
                "foo",
                "bar"
            };

            // Act
            PagingList<string> target = new PagingList<string>(expected);
            target.TotalCount = expected.Count;
            // Assert
            Assert.IsTrue(target.TotalCount == expected.Count);
        }


    }
}
