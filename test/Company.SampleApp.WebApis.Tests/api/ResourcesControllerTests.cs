#region Using Statements
using System;
using Company.SampleApp.Domain.Client.Dtos;
using Company.SampleApp.Domain.Client.Messages;
using Company.SampleApp.WebApis.api;
using Company.SampleApp.WebApis.Tests.ServiceMocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
#endregion

namespace Company.SampleApp.WebApis.Tests.api
{
    [TestClass]
    public class ResourcesControllerTests : ControllerTestsBase
    {
	    private ResourceServiceMock _service = new ResourceServiceMock();
        private ResourceServiceExceptionMock _errorService = new ResourceServiceExceptionMock();
        private Domain.MockData.Client.Dtos.Resources _mockdata =  new Domain.MockData.Client.Dtos.Resources();

		[TestMethod]
        public void CreateTest()
        {
            // Arrange
            ResourcesController target = new ResourcesController(_service);
            Resource expected = _mockdata.NewResource();

            // Act
            var actual = target.Post(expected) as CreatedAtRouteResult;

            // Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void ReadTest()
        {
            // Arrange
            ResourcesController target = new ResourcesController(_service);
            Resource expected = _mockdata.Resource1();

            // Act
            var actual = target.Get(expected.Id) as OkObjectResult;

            // Assert
            Assert.IsNotNull(actual);
        }
				
        [TestMethod]
        public void SearchByNameTest()
        {
            // Arrange
            ResourcesController target = new ResourcesController(_service);
            Resource expected = _mockdata.Resource1();
            ResourceSearchCriteria criteria = new ResourceSearchCriteria()
            {
                NameStartsWith = expected.Name
            };

            // Act
            var actual = target.Search(criteria) as OkObjectResult;

            // Assert
            Assert.IsNotNull(actual);
        }


        [TestMethod]
        public void UpdateTest()
        {
            // Arrange
            ResourcesController target = new ResourcesController(_service);
            Resource expected = _mockdata.UpdateResource1();
            expected.Name = "Updated Lookup Type from UpdateTest";

            // Act
            var actual = target.Put(expected.Id, expected) as OkObjectResult;

            // Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Arrange
            ResourcesController target = new ResourcesController(_service);
            Resource expected = _mockdata.DeleteResource1();
            // Act
            var actual = target.Delete(expected.Id) as OkResult;

            // Assert
            Assert.IsNotNull(actual);
        }

		//// BAD REQUESTS

        [TestMethod]
        public void CreateTest_BadRequest()
        {
            // Arrange
            ResourcesController target = new ResourcesController(_service);

            // Act
            var actual = target.Post(null) as BadRequestResult;

            // Assert
            Assert.IsNotNull(actual);

        }

        [TestMethod]
        public void ReadTest_NotFound()
        {
            // Arrange
            ResourcesController target = new ResourcesController(_service);

            // Act
            var actual = target.Get(0) as NotFoundResult;

            // Assert
            Assert.IsNotNull(actual);
        }
		
        [TestMethod]
        public void SearchByNameTest_BadRequest()
        {
            // Arrange
            ResourcesController target = new ResourcesController(_service);

            // Act
            var actual = target.Search(null) as BadRequestResult;

            // Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void UpdateTest_BadRequest()
        {
            // Arrange
            ResourcesController target = new ResourcesController(_service);

            // Act
            var actual = target.Put(0, null) as BadRequestResult;

            // Assert
            Assert.IsNotNull(actual);
        }
		
		//// EXCEPTIONS

        [TestMethod]
        public void CreateTest_Exception()
        {
            // Arrange
            ResourcesController target = new ResourcesController(_errorService);
            Resource expected = _mockdata.NewResource();

            // Act
            var actual = target.Post(expected) as ObjectResult;

            // Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void UpdateTest_Exception()
        {
            // Arrange
            ResourcesController target = new ResourcesController(_errorService);
            Resource expected = _mockdata.Resource1();
            expected.Name = "Updated Lookup Type from UpdateTest";

            // Act
            var actual = target.Put(expected.Id, expected) as ObjectResult;

            // Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void DeleteTest_Exception()
        {
            // Arrange
            ResourcesController target = new ResourcesController(_errorService);

            // Act
            var actual = target.Delete(-1) as ObjectResult;

            // Assert
            Assert.IsNotNull(actual);
        }


    }
}
