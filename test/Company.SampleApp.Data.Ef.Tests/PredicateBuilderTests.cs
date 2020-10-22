#region Using Statements
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Company.SampleApp.Data.Ef;
using System;
using System.Linq.Expressions;
#endregion

namespace Company.SampleApp.Data.Ef.Tests
{
    [TestClass]
    public class PredicateBuilderTests
    {
        [TestMethod]
        public void AndTest()
        {
            // Arrange
            Expression<Func<string, bool>> expression = (q => true);

            // Act
            expression.And(q => q.Length > 0);

            // Assert

        }

        [TestMethod]
        public void OrTest()
        {
            // Arrange
            Expression<Func<string, bool>> expression = (q => false);

            // Act
            expression.Or(q => q != null);

            // Assert

        }
    }
}
