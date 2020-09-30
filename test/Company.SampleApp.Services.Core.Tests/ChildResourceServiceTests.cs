#region Using Statements
using Company.SampleApp.Domain.Client.Dtos;
using Company.SampleApp.Domain.Client.Messages;
using Company.SampleApp.Services.Core.Tests.RepositoryMocks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
#endregion

namespace Company.SampleApp.Services.Core.Tests
{
    [TestClass]
    public class ChildResourceServiceTests : ServiceTestsBase
    {
	    private ChildResourceRepositoryMock _repository = new ChildResourceRepositoryMock();
        private ChildResourceRepositoryExceptionMock _exceptionRepository = new ChildResourceRepositoryExceptionMock();
		private Domain.MockData.Client.Dtos.ChildResources _mockdata = new Domain.MockData.Client.Dtos.ChildResources();
		private ILogger<ChildResourceService> _mockLogger = new Logger<ChildResourceService>(new NullLoggerFactory());
        
        [TestMethod]
        public void CreateTest()
        {
            // Arrange
            ChildResourceService target = new ChildResourceService(_repository, _mockLogger, _mapper);
            ChildResource expected = _mockdata.NewChildResource();

            // Act
            ChildResource actual = target.Create(expected);

            // Assert
            Assert.IsFalse(actual.Id == 0);
            Assert.IsFalse(target.HasError);
        }

        [TestMethod]
        public void ReadTest()
        {
            // Arrange
            ChildResourceService target = new ChildResourceService(_repository, _mockLogger, _mapper);
            ChildResource expected = _mockdata.ChildResource1();

            // Act
            ChildResource actual = target.Read(expected.Id);

            // Assert
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.IsFalse(target.HasError);
        }

        [TestMethod]
        public void ReadAllTest()
        {
            // Arrange
            ChildResourceService target = new ChildResourceService(_repository, _mockLogger, _mapper);
            List<ChildResource> expected = _mockdata.GetAll();

            // Act
            List<ChildResource> actual = target.ReadAll();

            // Assert
            Assert.IsTrue(actual.Count >= 0);
            Assert.IsFalse(target.HasError);
        }

		[TestMethod]
        public void SearchTest()
        {
            // Arrange
            ChildResourceService target = new ChildResourceService(_repository, _mockLogger, _mapper);
            ChildResource expected = _mockdata.ChildResource1();
            ChildResourceSearchCriteria criteria = new ChildResourceSearchCriteria()
            {
                SortFieldName = "Name",
                SortDirection = Domain.Client.Enumerations.SortDirection.Descending,
                PageSize = 10,
                PageNumber = 1,
                NameStartsWith = expected.Name
            };

            // Act
            List<ChildResource> actual = target.Search(criteria);

            // Assert
            Assert.IsFalse(target.HasError);
            Assert.IsTrue(actual.Count >= 0);
        }

        [TestMethod]
        public void SearchWithoutPagingOrSortingTest()
        {
            // Arrange
            ChildResourceService target = new ChildResourceService(_repository, _mockLogger, _mapper);
            ChildResource expected = _mockdata.ChildResource1();
            ChildResourceSearchCriteria criteria = new ChildResourceSearchCriteria()
            {
                SortFieldName = null,
                SortDirection = Domain.Client.Enumerations.SortDirection.Descending,
                PageSize = -1,
                PageNumber = 1,
                NameStartsWith = expected.Name
            };

            // Act
            List<ChildResource> actual = target.Search(criteria);

            // Assert
            Assert.IsFalse(target.HasError);
            Assert.IsTrue(actual.Count >= 0);
        }

        [TestMethod]
        public void SearchWithoutPagingSortedAscendingTest()
        {
            // Arrange
            ChildResourceService target = new ChildResourceService(_repository, _mockLogger, _mapper);
            ChildResource expected = _mockdata.ChildResource1();
            ChildResourceSearchCriteria criteria = new ChildResourceSearchCriteria()
            {
                SortFieldName = "Name",
                SortDirection = Domain.Client.Enumerations.SortDirection.Ascending,
                PageSize = -1,
                PageNumber = 1,
                NameStartsWith = expected.Name
            };

            // Act
            List<ChildResource> actual = target.Search(criteria);

            // Assert
            Assert.IsFalse(target.HasError);
            Assert.IsTrue(actual.Count >= 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            // Arrange
            ChildResourceService target = new ChildResourceService(_repository, _mockLogger, _mapper);
            ChildResource expected = _mockdata.UpdateChildResource1();
            expected.Name = Guid.NewGuid().ToString();

            // Act
            ChildResource actual = target.Update(expected);

            // Assert
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.IsFalse(target.HasError);
        }

        [TestMethod]
        public void UpdateInvalidTest()
        {
            // Arrange
            ChildResourceService target = new ChildResourceService(_repository, _mockLogger, _mapper);
            ChildResource expected = _mockdata.UpdateChildResource1();
            expected.Id = -1;
            expected.Name = Guid.NewGuid().ToString();

            // Act
            ChildResource actual = target.Update(expected);

            // Assert
            Assert.IsFalse(target.HasError);
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Arrange
            ChildResourceService target = new ChildResourceService(_repository, _mockLogger, _mapper);
            List<ChildResource> originalItems = _mockdata.GetAll();
            ChildResource expected = _mockdata.DeleteChildResource1();

            // Act
            target.Delete(expected.Id);
            List<ChildResource> updatedItems = target.ReadAll();

            // Assert
            Assert.IsFalse(target.HasError);
        }

        [TestMethod]
        public void DeleteNullItemsTest()
        {
            // Arrange
            ChildResourceService target = new ChildResourceService(_repository, _mockLogger, _mapper);

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
            ChildResourceService target = new ChildResourceService(_exceptionRepository, _mockLogger, _mapper);
            ChildResource expected = _mockdata.NewChildResource();

            // Act
            ChildResource actual = target.Create(expected);

            // Assert
            Assert.IsTrue(target.HasError);
        }

        [TestMethod]
        public void ReadTest_Exception()
        {
            // Arrange
            ChildResourceService target = new ChildResourceService(_exceptionRepository, _mockLogger, _mapper);
            ChildResource expected = _mockdata.ChildResource1();

            // Act
            ChildResource actual = target.Read(expected.Id);

            // Assert
            Assert.IsNull(actual);
            Assert.IsTrue(target.HasError);
        }

        [TestMethod]
        public void ReadAllTest_Exception()
        {
            // Arrange
            ChildResourceService target = new ChildResourceService(_exceptionRepository, _mockLogger, _mapper);
            
            // Act
            List<ChildResource> actual = target.ReadAll();

            // Assert
            Assert.IsNull(actual);
            Assert.IsTrue(target.HasError);
        }
		
        [TestMethod]
        public void SearchTest_Exception()
        {
            // Arrange
            ChildResourceService target = new ChildResourceService(_exceptionRepository, _mockLogger, _mapper);
            ChildResourceSearchCriteria criteria = new ChildResourceSearchCriteria();

            // Act
            PagingList<ChildResource> actual = target.Search(criteria);

            // Assert
            Assert.IsTrue(target.HasError);
        }

        [TestMethod]
        public void UpdateTest_Exception()
        {
            // Arrange
            ChildResourceService target = new ChildResourceService(_exceptionRepository, _mockLogger, _mapper);
            ChildResource expected = _mockdata.UpdateChildResource1();
            expected.Name = Guid.NewGuid().ToString();

            // Act
            ChildResource actual = target.Update(expected);

            // Assert
            Assert.IsTrue(target.HasError);
        }

        [TestMethod]
        public void DeleteTest_Exception()
        {
            // Arrange
            ChildResourceService target = new ChildResourceService(_exceptionRepository, _mockLogger, _mapper);
            ChildResource expected = _mockdata.DeleteChildResource1();

            // Act
            target.Delete(expected.Id);

            // Assert
            Assert.IsTrue(target.HasError);
        }


    }
}
