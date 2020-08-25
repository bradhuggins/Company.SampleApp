#region Using Statements
using System;
using System.Collections.Generic;
using Company.SampleApp.Domain.Client.Dtos;
using Company.SampleApp.Domain.Client.Messages;
using Company.SampleApp.Services.Core.Tests;
using Company.SampleApp.Services.Core.Tests.RepositoryMocks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endregion

namespace Company.SampleApp.Services.Core.Tests
{
    [TestClass]
    public class OtherResourceServiceTests : ServiceTestsBase
    {
	    private OtherResourceRepositoryMock _repository = new OtherResourceRepositoryMock();
        private OtherResourceRepositoryExceptionMock _exceptionRepository = new OtherResourceRepositoryExceptionMock();
		private Domain.MockData.Client.Dtos.OtherResources _mockdata = new Domain.MockData.Client.Dtos.OtherResources();
		private ILogger<OtherResourceService> _mockLogger = new Logger<OtherResourceService>(new NullLoggerFactory());
        
        [TestMethod]
        public void CreateTest()
        {
            // Arrange
            OtherResourceService target = new OtherResourceService(_repository, _mockLogger, this.Configuration, _mapper);
            OtherResource expected = _mockdata.NewOtherResource();

            // Act
            OtherResource actual = target.Create(expected);

            // Assert
            Assert.IsFalse(actual.Id == 0);
            Assert.IsFalse(target.HasError);
        }

        [TestMethod]
        public void ReadTest()
        {
            // Arrange
            OtherResourceService target = new OtherResourceService(_repository, _mockLogger, this.Configuration, _mapper);
            OtherResource expected = _mockdata.OtherResource1();

            // Act
            OtherResource actual = target.Read(expected.Id);

            // Assert
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.IsFalse(target.HasError);
        }

        [TestMethod]
        public void ReadAllTest()
        {
            // Arrange
            OtherResourceService target = new OtherResourceService(_repository, _mockLogger, this.Configuration, _mapper);
            List<OtherResource> expected = _mockdata.GetAll();

            // Act
            List<OtherResource> actual = target.ReadAll();

            // Assert
            Assert.IsTrue(actual.Count >= 0);
            Assert.IsFalse(target.HasError);
        }

		[TestMethod]
        public void SearchTest()
        {
            // Arrange
            OtherResourceService target = new OtherResourceService(_repository, _mockLogger, this.Configuration, _mapper);
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
            Assert.IsFalse(target.HasError);
            Assert.IsTrue(actual.Count >= 0);
        }

        [TestMethod]
        public void SearchWithoutPagingOrSortingTest()
        {
            // Arrange
            OtherResourceService target = new OtherResourceService(_repository, _mockLogger, this.Configuration, _mapper);
            OtherResource expected = _mockdata.OtherResource1();
            OtherResourceSearchCriteria criteria = new OtherResourceSearchCriteria()
            {
                SortFieldName = null,
                SortDirection = Domain.Client.Enumerations.SortDirection.Descending,
                PageSize = -1,
                PageNumber = 1,
                NameStartsWith = expected.Name
            };

            // Act
            List<OtherResource> actual = target.Search(criteria);

            // Assert
            Assert.IsFalse(target.HasError);
            Assert.IsTrue(actual.Count >= 0);
        }

        [TestMethod]
        public void SearchWithoutPagingSortedAscendingTest()
        {
            // Arrange
            OtherResourceService target = new OtherResourceService(_repository, _mockLogger, this.Configuration, _mapper);
            OtherResource expected = _mockdata.OtherResource1();
            OtherResourceSearchCriteria criteria = new OtherResourceSearchCriteria()
            {
                SortFieldName = "Name",
                SortDirection = Domain.Client.Enumerations.SortDirection.Ascending,
                PageSize = -1,
                PageNumber = 1,
                NameStartsWith = expected.Name
            };

            // Act
            List<OtherResource> actual = target.Search(criteria);

            // Assert
            Assert.IsFalse(target.HasError);
            Assert.IsTrue(actual.Count >= 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            // Arrange
            OtherResourceService target = new OtherResourceService(_repository, _mockLogger, this.Configuration, _mapper);
            OtherResource expected = _mockdata.UpdateOtherResource1();
            expected.Name = Guid.NewGuid().ToString();

            // Act
            OtherResource actual = target.Update(expected);

            // Assert
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.IsFalse(target.HasError);
        }

        [TestMethod]
        public void UpdateInvalidTest()
        {
            // Arrange
            OtherResourceService target = new OtherResourceService(_repository, _mockLogger, this.Configuration, _mapper);
            OtherResource expected = _mockdata.UpdateOtherResource1();
            expected.Id = -1;
            expected.Name = Guid.NewGuid().ToString();

            // Act
            OtherResource actual = target.Update(expected);

            // Assert
            Assert.IsFalse(target.HasError);
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Arrange
            OtherResourceService target = new OtherResourceService(_repository, _mockLogger, this.Configuration, _mapper);
            List<OtherResource> originalItems = _mockdata.GetAll();
            OtherResource expected = _mockdata.DeleteOtherResource1();

            // Act
            target.Delete(expected.Id);
            List<OtherResource> updatedItems = target.ReadAll();

            // Assert
            Assert.IsFalse(target.HasError);
        }

        [TestMethod]
        public void DeleteNullItemsTest()
        {
            // Arrange
            OtherResourceService target = new OtherResourceService(_repository, _mockLogger, this.Configuration, _mapper);
            // Act
            target.Delete(-1);

            // Assert
            Assert.IsFalse(target.HasError);
        }

        //// EXCEPTIONS
		
        [TestMethod]
        public void CreateTest_Exception()
        {
            // Arrange
            OtherResourceService target = new OtherResourceService(_exceptionRepository, _mockLogger, this.Configuration, _mapper);
            OtherResource expected = _mockdata.NewOtherResource();

            // Act
            OtherResource actual = target.Create(expected);

            // Assert
            Assert.IsTrue(target.HasError);
        }

        [TestMethod]
        public void ReadTest_Exception()
        {
            // Arrange
            OtherResourceService target = new OtherResourceService(_exceptionRepository, _mockLogger, this.Configuration, _mapper);
            OtherResource expected = _mockdata.OtherResource1();

            // Act
            OtherResource actual = target.Read(expected.Id);

            // Assert
            Assert.IsNull(actual);
            Assert.IsTrue(target.HasError);
        }

        [TestMethod]
        public void ReadAllTest_Exception()
        {
            // Arrange
            OtherResourceService target = new OtherResourceService(_exceptionRepository, _mockLogger, this.Configuration, _mapper);

            // Act
            List<OtherResource> actual = target.ReadAll();

            // Assert
            Assert.IsNull(actual);
            Assert.IsTrue(target.HasError);
        }
		
        [TestMethod]
        public void SearchTest_Exception()
        {
            // Arrange
            OtherResourceService target = new OtherResourceService(_exceptionRepository, _mockLogger, this.Configuration, _mapper);
            OtherResourceSearchCriteria criteria = new OtherResourceSearchCriteria();

            // Act
            List<OtherResource> actual = target.Search(criteria);

            // Assert
            Assert.IsTrue(target.HasError);
        }

        [TestMethod]
        public void UpdateTest_Exception()
        {
            // Arrange
            OtherResourceService target = new OtherResourceService(_exceptionRepository, _mockLogger, this.Configuration, _mapper);
            OtherResource expected = _mockdata.UpdateOtherResource1();
            expected.Name = Guid.NewGuid().ToString();

            // Act
            OtherResource actual = target.Update(expected);

            // Assert
            Assert.IsTrue(target.HasError);
        }

        [TestMethod]
        public void DeleteTest_Exception()
        {
            // Arrange
            OtherResourceService target = new OtherResourceService(_exceptionRepository, _mockLogger, this.Configuration, _mapper);
            OtherResource expected = _mockdata.DeleteOtherResource1();

            // Act
            target.Delete(expected.Id);

            // Assert
            Assert.IsTrue(target.HasError);
        }


    }
}
