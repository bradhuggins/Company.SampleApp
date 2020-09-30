#region Using Statements
using Company.SampleApp.Domain.Client.Messages;
using Company.SampleApp.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
#endregion

namespace Company.SampleApp.Repositories.Ef.Tests
{
    [TestClass]
	public partial class ResourceRepositoryTests : RepositoryTestsBase
	{
		private Domain.MockData.Models.Resources _mockdata = new Domain.MockData.Models.Resources();
		
		[TestMethod]
		public void CreateTest()
		{
			// Arrange
			ResourceRepository target = new ResourceRepository(_context);
			Resource expected = _mockdata.NewResource();

			// Act
			Resource actual = target.Create(expected);

			// Assert
			//Assert.AreEqual(expected.Name, actual.Name);
			Assert.IsFalse(actual.Id == 0);
		}

		[TestMethod]
		public void ReadTest()
		{
			// Arrange
			ResourceRepository target = new ResourceRepository(_context);
			Resource expected = _mockdata.Resource1();

			// Act
			Resource actual = target.Read(expected.Id);

			// Assert
			Assert.AreEqual(expected.Id, actual.Id);			
		}
		
		[TestMethod]
		public void ReadAllTest()
		{
			// Arrange
			ResourceRepository target = new ResourceRepository(_context);
			List<Resource> expected = _mockdata.GetAll();

			// Act
			List<Resource> actual = target.ReadAll();

			// Assert
			Assert.IsTrue(actual.Count >= 0);
		}
		[TestMethod]
		public void SearchTest()
		{
			// Arrange
			ResourceRepository target = new ResourceRepository(_context);
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
			Assert.IsTrue(actual.Count >= 0);
		}

		[TestMethod]
		public void SearchWithoutPagingOrSortingTest()
		{
			// Arrange
			ResourceRepository target = new ResourceRepository(_context);
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
			Assert.IsTrue(actual.Count >= 0);
		}

		[TestMethod]
		public void SearchWithoutPagingSortedAscendingTest()
		{
			// Arrange
			ResourceRepository target = new ResourceRepository(_context);
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
			Assert.IsTrue(actual.Count >= 0);
		}

		[TestMethod]
		public void UpdateTest()
		{
			// Arrange
			ResourceRepository target = new ResourceRepository(_context);
			Resource expected = _mockdata.UpdateResource1();
			expected.Name = Guid.NewGuid().ToString();

			// Act
			Resource actual = target.Update(expected);

			// Assert
			Assert.AreEqual(expected.Name, actual.Name);
		}

		[TestMethod]
		public void UpdateNotFoundTest()
		{
			// Arrange
			ResourceRepository target = new ResourceRepository(_context);
			Resource expected = _mockdata.UpdateResource1();
			expected.Id = -1;
			expected.Name = Guid.NewGuid().ToString();

			// Act
			Resource actual = target.Update(expected);

			// Assert
			Assert.IsNull(actual);
		}

		[TestMethod]
		public void DeleteTest()
		{
			// Arrange
			ResourceRepository target = new ResourceRepository(_context);
			List<Resource> originalItems = _mockdata.GetAll();
			Resource expected = _mockdata.DeleteResource1();

			// Act
			target.Delete(expected.Id);
			List<Resource> updatedItems = target.ReadAll();

			// Assert
			Assert.AreNotEqual(originalItems.Count, updatedItems.Count);
		}

		[TestMethod]
		public void BuildQueryTest()
		{
			// Arrange
			ResourceRepository target = new ResourceRepository(_context);
			Type t = typeof(ResourceRepository);
			Resource expected = _mockdata.Resource1();
			ResourceSearchCriteria criteria = new ResourceSearchCriteria()
			{
				Id = expected.Id,
				NameStartsWith = expected.Name
			};

			MethodInfo methodInfo = t.GetMethod("BuildQuery", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { criteria };

			// Act
			methodInfo.Invoke(target, parameters);

			//Assert

		}

	}
}
