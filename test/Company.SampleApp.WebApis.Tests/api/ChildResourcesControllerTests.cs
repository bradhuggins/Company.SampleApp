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
    public class ChildResourcesControllerTests : ControllerTestsBase
    {
	    private ChildResourceServiceMock _service = new ChildResourceServiceMock();
        private ChildResourceServiceExceptionMock _errorService = new ChildResourceServiceExceptionMock();
        private Domain.MockData.Client.Dtos.ChildResources _mockdata =  new Domain.MockData.Client.Dtos.ChildResources();

		[TestMethod]
        public void PostTest()
        {
            // Arrange
            ChildResourcesController target = new ChildResourcesController(_service);
            ChildResource expected = _mockdata.NewChildResource();

            // Act
            var actual = target.Post(expected) as CreatedAtRouteResult;

            // Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void GetTest()
        {
            // Arrange
            ChildResourcesController target = new ChildResourcesController(_service);
            ChildResource expected = _mockdata.ChildResource1();

            // Act
            var actual = target.Get(expected.Id) as OkObjectResult;

            // Assert
            Assert.IsNotNull(actual);
        }
				
        [TestMethod]
        public void SearchByNameTest()
        {
            // Arrange
            ChildResourcesController target = new ChildResourcesController(_service);
            ChildResource expected = _mockdata.ChildResource1();
            ChildResourceSearchCriteria criteria = new ChildResourceSearchCriteria()
            {
                NameStartsWith = expected.Name
            };

            // Act
            var actual = target.Search(criteria) as OkObjectResult;

            // Assert
            Assert.IsNotNull(actual);
        }


        [TestMethod]
        public void PutTest()
        {
            // Arrange
            ChildResourcesController target = new ChildResourcesController(_service);
            ChildResource expected = _mockdata.UpdateChildResource1();
            expected.Name = Guid.NewGuid().ToString();

            // Act
            var actual = target.Put(expected.Id, expected) as OkObjectResult;

            // Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Arrange
            ChildResourcesController target = new ChildResourcesController(_service);
            ChildResource expected = _mockdata.DeleteChildResource1();
            // Act
            var actual = target.Delete(expected.Id) as NoContentResult;

            // Assert
            Assert.IsNotNull(actual);
        }

		//// BAD REQUESTS

        [TestMethod]
        public void PostTest_BadRequest()
        {
            // Arrange
            ChildResourcesController target = new ChildResourcesController(_service);

            // Act
            var actual = target.Post(null) as BadRequestResult;

            // Assert
            Assert.IsNotNull(actual);

        }

        [TestMethod]
        public void GetTest_NotFound()
        {
            // Arrange
            ChildResourcesController target = new ChildResourcesController(_service);

            // Act
            var actual = target.Get(0) as NotFoundResult;

            // Assert
            Assert.IsNotNull(actual);
        }
		
        [TestMethod]
        public void SearchByNameTest_BadRequest()
        {
            // Arrange
            ChildResourcesController target = new ChildResourcesController(_service);

            // Act
            var actual = target.Search(null) as BadRequestResult;

            // Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void PutTest_BadRequest()
        {
            // Arrange
            ChildResourcesController target = new ChildResourcesController(_service);

            // Act
            var actual = target.Put(0, null) as BadRequestResult;

            // Assert
            Assert.IsNotNull(actual);
        }
		
		//// EXCEPTIONS

        [TestMethod]
        public void PostTest_Exception()
        {
            // Arrange
            ChildResourcesController target = new ChildResourcesController(_errorService);
            ChildResource expected = _mockdata.NewChildResource();

            // Act
            var actual = target.Post(expected) as ObjectResult;

            // Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void PutTest_Exception()
        {
            // Arrange
            ChildResourcesController target = new ChildResourcesController(_errorService);
            ChildResource expected = _mockdata.ChildResource1();
            expected.Name = Guid.NewGuid().ToString();

            // Act
            var actual = target.Put(expected.Id, expected) as ObjectResult;

            // Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void DeleteTest_Exception()
        {
            // Arrange
            ChildResourcesController target = new ChildResourcesController(_errorService);

            // Act
            var actual = target.Delete(-1) as ObjectResult;

            // Assert
            Assert.IsNotNull(actual);
        }


    }
}
