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
    public class OtherResourcesControllerTests : ControllerTestsBase
    {
	    private OtherResourceServiceMock _service = new OtherResourceServiceMock();
        private OtherResourceServiceExceptionMock _errorService = new OtherResourceServiceExceptionMock();
        private Domain.MockData.Client.Dtos.OtherResources _mockdata =  new Domain.MockData.Client.Dtos.OtherResources();

		[TestMethod]
        public void CreateTest()
        {
            // Arrange
            OtherResourcesController target = new OtherResourcesController(_service);
            OtherResource expected = _mockdata.NewOtherResource();

            // Act
            var actual = target.Post(expected) as CreatedAtRouteResult;

            // Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void ReadTest()
        {
            // Arrange
            OtherResourcesController target = new OtherResourcesController(_service);
            OtherResource expected = _mockdata.OtherResource1();

            // Act
            var actual = target.Get(expected.Id) as OkObjectResult;

            // Assert
            Assert.IsNotNull(actual);
        }
				
        [TestMethod]
        public void SearchByNameTest()
        {
            // Arrange
            OtherResourcesController target = new OtherResourcesController(_service);
            OtherResource expected = _mockdata.OtherResource1();
            OtherResourceSearchCriteria criteria = new OtherResourceSearchCriteria()
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
            OtherResourcesController target = new OtherResourcesController(_service);
            OtherResource expected = _mockdata.UpdateOtherResource1();
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
            OtherResourcesController target = new OtherResourcesController(_service);
            OtherResource expected = _mockdata.DeleteOtherResource1();
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
            OtherResourcesController target = new OtherResourcesController(_service);

            // Act
            var actual = target.Post(null) as BadRequestResult;

            // Assert
            Assert.IsNotNull(actual);

        }

        [TestMethod]
        public void ReadTest_NotFound()
        {
            // Arrange
            OtherResourcesController target = new OtherResourcesController(_service);

            // Act
            var actual = target.Get(0) as NotFoundResult;

            // Assert
            Assert.IsNotNull(actual);
        }
		
        [TestMethod]
        public void SearchByNameTest_BadRequest()
        {
            // Arrange
            OtherResourcesController target = new OtherResourcesController(_service);

            // Act
            var actual = target.Search(null) as BadRequestResult;

            // Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void UpdateTest_BadRequest()
        {
            // Arrange
            OtherResourcesController target = new OtherResourcesController(_service);

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
            OtherResourcesController target = new OtherResourcesController(_errorService);
            OtherResource expected = _mockdata.NewOtherResource();

            // Act
            var actual = target.Post(expected) as ObjectResult;

            // Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void UpdateTest_Exception()
        {
            // Arrange
            OtherResourcesController target = new OtherResourcesController(_errorService);
            OtherResource expected = _mockdata.OtherResource1();
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
            OtherResourcesController target = new OtherResourcesController(_errorService);

            // Act
            var actual = target.Delete(-1) as ObjectResult;

            // Assert
            Assert.IsNotNull(actual);
        }


    }
}
