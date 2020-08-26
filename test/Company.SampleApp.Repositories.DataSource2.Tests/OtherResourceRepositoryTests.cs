#region Using Statements
using Company.SampleApp.Domain.Client.Messages;
using Company.SampleApp.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
#endregion

namespace Company.SampleApp.Repositories.DataSource2.Tests
{
    [TestClass]
    public class OtherResourceRepositoryTests : RepositoryTestsBase
    {
        private Domain.MockData.Models.OtherResources _mockdata = new Domain.MockData.Models.OtherResources();

        [TestMethod]
        public void ConnectionStringGetErrorTest()
        {
            // Arrange
            OtherResourceRepository target = new OtherResourceRepository();

            // Act
            string error = null;
            try
            {
                var actual = target.ConnectionString;
            }
            catch (Exception ex)
            {
                error = ex.ToString();
            }
            // Assert
            Assert.IsNotNull(error);
        }

        [TestMethod]
        public void CreateTest()
        {
            // Arrange
            OtherResourceRepository target = new OtherResourceRepository();
            target.ConnectionString = this.Configuration.GetConnectionString("DataSource2");
            OtherResource expected = _mockdata.NewOtherResource();

            // Act
            OtherResource actual = target.Create(expected);

            // Assert
            //Assert.AreEqual(expected.Name, actual.Name);
            Assert.IsFalse(actual.Id == 0);
        }

        //// below assumes record exists in database
        //[TestMethod]
        //public void ReadTest()
        //{
        //    // Arrange
        //    OtherResourceRepository target = new OtherResourceRepository();
        //    target.ConnectionString = this.Configuration.GetConnectionString("DataSource2");
        //    OtherResource expected = _mockdata.OtherResource1();

        //    // Act
        //    OtherResource actual = target.Read(expected.Id);

        //    // Assert
        //    Assert.AreEqual(expected.Id, actual.Id);
        //}

        [TestMethod]
        public void ReadNotFoundTest()
        {
            // Arrange
            OtherResourceRepository target = new OtherResourceRepository();
            target.ConnectionString = this.Configuration.GetConnectionString("DataSource2");

            // Act
            OtherResource actual = target.Read(-1);

            // Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void ReadAllTest()
        {
            // Arrange
            OtherResourceRepository target = new OtherResourceRepository();
            target.ConnectionString = this.Configuration.GetConnectionString("DataSource2");

            // Act
            List<OtherResource> actual = target.ReadAll();

            // Assert
            Assert.IsTrue(actual.Count >= 0);
        }

        [TestMethod]
        public void SearchTest()
        {
            // Arrange
            OtherResourceRepository target = new OtherResourceRepository();
            target.ConnectionString = this.Configuration.GetConnectionString("DataSource2");
            OtherResource expected = _mockdata.OtherResource1();
            OtherResourceSearchCriteria criteria = new OtherResourceSearchCriteria()
            {
                SortFieldName = "Name",
                SortDirection = Domain.Client.Enumerations.SortDirection.Descending,
                PageSize = 10,
                PageNumber = 1,
                NameStartsWith = expected.Name
            };

            // Act
            List<OtherResource> actual = target.Search(criteria);

            // Assert
            Assert.IsTrue(actual.Count >= 0);
        }

        ////// below assumes record exists in database
        //[TestMethod]
        //public void UpdateTest()
        //{
        //    // Arrange
        //    OtherResourceRepository target = new OtherResourceRepository();
        //    target.ConnectionString = this.Configuration.GetConnectionString("DataSource2");
        //    OtherResource expected = _mockdata.OtherResource1();
        //    expected.Name = Guid.NewGuid().ToString();

        //    // Act
        //    OtherResource actual = target.Update(expected);

        //    // Assert
        //    Assert.AreEqual(expected.Name, actual.Name);
        //}

        [TestMethod]
        public void UpdateNotFoundTest()
        {
            // Arrange
            OtherResourceRepository target = new OtherResourceRepository();
            target.ConnectionString = this.Configuration.GetConnectionString("DataSource2");
            OtherResource expected = _mockdata.OtherResource1();
            expected.Id = -1;
            expected.Name = Guid.NewGuid().ToString();

            // Act
            OtherResource actual = target.Update(expected);

            // Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Arrange
            OtherResourceRepository target = new OtherResourceRepository();
            target.ConnectionString = this.Configuration.GetConnectionString("DataSource2");
            OtherResource expected = _mockdata.DeleteOtherResource1();

            // Act
            target.Delete(expected.Id);

            // Assert            
        }

        [TestMethod]
        public void BuildQueryTest()
        {
            // Arrange
            OtherResourceRepository target = new OtherResourceRepository();
            target.ConnectionString = this.Configuration.GetConnectionString("DataSource2");
            Type t = typeof(OtherResourceRepository);
            OtherResource expected = _mockdata.OtherResource1();
            OtherResourceSearchCriteria criteria = new OtherResourceSearchCriteria()
            {
                Id = expected.Id,
                NameStartsWith = expected.Name
            };

            MethodInfo methodInfo = t.GetMethod("BuildQuery", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { criteria };

            // Act
            string actual = (string)methodInfo.Invoke(target, parameters);

            //Assert
            Assert.IsTrue(actual.Length > 0);
        }

    }
}
