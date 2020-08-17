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
    public class ResourceServiceTests : ServiceTestsBase
    {
	    private ResourceRepositoryMock _repository = new ResourceRepositoryMock();
        private ResourceRepositoryExceptionMock _exceptionRepository = new ResourceRepositoryExceptionMock();
		private Domain.MockData.Client.Dtos.Resources _mockdata = new Domain.MockData.Client.Dtos.Resources();
		private ILogger<ResourceService> _mockLogger = new Logger<ResourceService>(new NullLoggerFactory());
        
        [TestMethod]
        public void CreateTest()
        {
            // Arrange
            ResourceService target = new ResourceService(_repository, _mockLogger, _mapper);
            Resource expected = _mockdata.NewResource();

            // Act
            Resource actual = target.Create(expected);

            // Assert
            Assert.IsFalse(actual.Id == 0);
            Assert.IsFalse(target.HasError);
        }

        [TestMethod]
        public void ReadTest()
        {
            // Arrange
            ResourceService target = new ResourceService(_repository, _mockLogger, _mapper);
            Resource expected = _mockdata.Resource1();

            // Act
            Resource actual = target.Read(expected.Id);

            // Assert
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.IsFalse(target.HasError);
        }

        [TestMethod]
        public void ReadAllTest()
        {
            // Arrange
            ResourceService target = new ResourceService(_repository, _mockLogger, _mapper);
            List<Resource> expected = _mockdata.GetAll();

            // Act
            List<Resource> actual = target.ReadAll();

            // Assert
            Assert.IsTrue(actual.Count >= 0);
            Assert.IsFalse(target.HasError);
        }

		[TestMethod]
        public void SearchTest()
        {
            // Arrange
            ResourceService target = new ResourceService(_repository, _mockLogger, _mapper);
            Resource expected = _mockdata.Resource1();
            ResourceSearchCriteria criteria = new ResourceSearchCriteria()
            {
                SortFieldName = "Name",
                SortDirection = Domain.Client.Enumerations.SortDirection.Descending,
                PageSize = 10,
                PageNumber = 1,
                NameStartsWith = expected.Name
            };

            // Act
            List<Resource> actual = target.Search(criteria);

            // Assert
            Assert.IsFalse(target.HasError);
            Assert.IsTrue(actual.Count >= 0);
        }

        [TestMethod]
        public void SearchWithoutPagingOrSortingTest()
        {
            // Arrange
            ResourceService target = new ResourceService(_repository, _mockLogger, _mapper);
            Resource expected = _mockdata.Resource1();
            ResourceSearchCriteria criteria = new ResourceSearchCriteria()
            {
                SortFieldName = null,
                SortDirection = Domain.Client.Enumerations.SortDirection.Descending,
                PageSize = -1,
                PageNumber = 1,
                NameStartsWith = expected.Name
            };

            // Act
            List<Resource> actual = target.Search(criteria);

            // Assert
            Assert.IsFalse(target.HasError);
            Assert.IsTrue(actual.Count >= 0);
        }

        [TestMethod]
        public void SearchWithoutPagingSortedAscendingTest()
        {
            // Arrange
            ResourceService target = new ResourceService(_repository, _mockLogger, _mapper);
            Resource expected = _mockdata.Resource1();
            ResourceSearchCriteria criteria = new ResourceSearchCriteria()
            {
                SortFieldName = "Name",
                SortDirection = Domain.Client.Enumerations.SortDirection.Ascending,
                PageSize = -1,
                PageNumber = 1,
                NameStartsWith = expected.Name
            };

            // Act
            List<Resource> actual = target.Search(criteria);

            // Assert
            Assert.IsFalse(target.HasError);
            Assert.IsTrue(actual.Count >= 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            // Arrange
            ResourceService target = new ResourceService(_repository, _mockLogger, _mapper);
            Resource expected = _mockdata.UpdateResource1();
            expected.Name = Guid.NewGuid().ToString();

            // Act
            Resource actual = target.Update(expected);

            // Assert
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.IsFalse(target.HasError);
        }

        [TestMethod]
        public void UpdateInvalidTest()
        {
            // Arrange
            ResourceService target = new ResourceService(_repository, _mockLogger, _mapper);
            Resource expected = _mockdata.UpdateResource1();
            expected.Id = -1;
            expected.Name = Guid.NewGuid().ToString();

            // Act
            Resource actual = target.Update(expected);

            // Assert
            Assert.IsFalse(target.HasError);
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Arrange
            ResourceService target = new ResourceService(_repository, _mockLogger, _mapper);
            List<Resource> originalItems = _mockdata.GetAll();
            Resource expected = _mockdata.DeleteResource1();

            // Act
            target.Delete(expected.Id);
            List<Resource> updatedItems = target.ReadAll();

            // Assert
            Assert.IsFalse(target.HasError);
        }

        [TestMethod]
        public void DeleteNullItemsTest()
        {
            // Arrange
            ResourceService target = new ResourceService(_repository, _mockLogger, _mapper);

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
            ResourceService target = new ResourceService(_exceptionRepository, _mockLogger, _mapper);
            Resource expected = _mockdata.NewResource();

            // Act
            Resource actual = target.Create(expected);

            // Assert
            Assert.IsTrue(target.HasError);
        }

        [TestMethod]
        public void ReadTest_Exception()
        {
            // Arrange
            ResourceService target = new ResourceService(_exceptionRepository, _mockLogger, _mapper);
            Resource expected = _mockdata.Resource1();

            // Act
            Resource actual = target.Read(expected.Id);

            // Assert
            Assert.IsNull(actual);
            Assert.IsTrue(target.HasError);
        }

        [TestMethod]
        public void ReadAllTest_Exception()
        {
            // Arrange
            ResourceService target = new ResourceService(_exceptionRepository, _mockLogger, _mapper);
            
            // Act
            List<Resource> actual = target.ReadAll();

            // Assert
            Assert.IsNull(actual);
            Assert.IsTrue(target.HasError);
        }
		
        [TestMethod]
        public void SearchTest_Exception()
        {
            // Arrange
            ResourceService target = new ResourceService(_exceptionRepository, _mockLogger, _mapper);
            ResourceSearchCriteria criteria = new ResourceSearchCriteria();

            // Act
            PagingList<Resource> actual = target.Search(criteria);

            // Assert
            Assert.IsTrue(target.HasError);
        }

        [TestMethod]
        public void UpdateTest_Exception()
        {
            // Arrange
            ResourceService target = new ResourceService(_exceptionRepository, _mockLogger, _mapper);
            Resource expected = _mockdata.UpdateResource1();
            expected.Name = Guid.NewGuid().ToString();

            // Act
            Resource actual = target.Update(expected);

            // Assert
            Assert.IsTrue(target.HasError);
        }

        [TestMethod]
        public void DeleteTest_Exception()
        {
            // Arrange
            ResourceService target = new ResourceService(_exceptionRepository, _mockLogger, _mapper);
            Resource expected = _mockdata.DeleteResource1();

            // Act
            target.Delete(expected.Id);

            // Assert
            Assert.IsTrue(target.HasError);
        }


    }
}
