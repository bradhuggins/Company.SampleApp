#region Using Statements
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Company.SampleApp.Data.Ef;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace Company.SampleApp.Data.Ef.Tests
{
    [TestClass]
    public class QueryableExtensionsTests
    {
        [TestMethod]
        public void OrderByTest()
        {
            // Arrange
            IQueryable<KeyValuePair<string, string>> expected = new Dictionary<string, string>().AsQueryable();

            // Act
            IOrderedQueryable<KeyValuePair<string, string>> actual = expected.OrderBy("Key");

            // Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void OrderByWithDirectionTest()
        {
            // Arrange
            IQueryable<KeyValuePair<string, string>> expected = new Dictionary<string, string>().AsQueryable();

            // Act
            IOrderedQueryable<KeyValuePair<string, string>> actual = expected.OrderBy("Key", "ASC");

            // Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void OrderByDescendingTest()
        {
            // Arrange
            IQueryable<KeyValuePair<string, string>> expected = new Dictionary<string, string>().AsQueryable();

            // Act
            IOrderedQueryable<KeyValuePair<string, string>> actual = expected.OrderByDescending("Key");

            // Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void ThenByTest()
        {
            // Arrange
            IQueryable<KeyValuePair<string, string>> expected = new Dictionary<string, string>().AsQueryable();

            // Act
            IOrderedQueryable<KeyValuePair<string, string>> actual = expected.OrderBy("Key").ThenBy("Value");

            // Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void ThenByWithDirectionAscendingTest()
        {
            // Arrange
            IQueryable<KeyValuePair<string, string>> expected = new Dictionary<string, string>().AsQueryable();

            // Act
            IOrderedQueryable<KeyValuePair<string, string>> actual = expected.OrderBy("Key", "ASC").ThenBy("Value", "ASC");

            // Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void ThenByWithDirectionDescendingTest()
        {
            // Arrange
            IQueryable<KeyValuePair<string, string>> expected = new Dictionary<string, string>().AsQueryable();

            // Act
            IOrderedQueryable<KeyValuePair<string, string>> actual = expected.OrderBy("Key", "DESC").ThenBy("Value", "DESC");

            // Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void ThenByDescendingTest()
        {
            // Arrange
            IQueryable<KeyValuePair<string, string>> expected = new Dictionary<string, string>().AsQueryable();

            // Act
            IOrderedQueryable<KeyValuePair<string, string>> actual = expected.OrderBy("Key").ThenByDescending("Value");

            // Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void IncludePropertyListCsvTest()
        {
            // Arrange
            IQueryable<string> expected = new List<string>().AsQueryable();

            // Act
            IQueryable<string> actual = expected.IncludePropertyListCsv("x,y,z");

            // Assert
            Assert.IsNotNull(actual);
        }




    }
}
