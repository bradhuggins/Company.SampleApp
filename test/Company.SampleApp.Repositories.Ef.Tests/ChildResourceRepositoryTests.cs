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
	public partial class ChildResourceRepositoryTests : RepositoryTestsBase
	{
		private Domain.MockData.Models.ChildResources _mockdata = new Domain.MockData.Models.ChildResources();
		
		[TestMethod]
		public void CreateTest()
		{
			// Arrange
			ChildResourceRepository target = new ChildResourceRepository(_context);
			ChildResource expected = _mockdata.NewChildResource();

			// Act
			ChildResource actual = target.Create(expected);

			// Assert
			//Assert.AreEqual(expected.Name, actual.Name);
			Assert.IsFalse(actual.Id == 0);
		}

		[TestMethod]
		public void ReadTest()
		{
			// Arrange
			ChildResourceRepository target = new ChildResourceRepository(_context);
			ChildResource expected = _mockdata.ChildResource1();

			// Act
			ChildResource actual = target.Read(expected.Id);

			// Assert
			Assert.AreEqual(expected.Id, actual.Id);			
		}
		
		[TestMethod]
		public void ReadAllTest()
		{
			// Arrange
			ChildResourceRepository target = new ChildResourceRepository(_context);
			List<ChildResource> expected = _mockdata.GetAll();

			// Act
			List<ChildResource> actual = target.ReadAll();

			// Assert
			Assert.IsTrue(actual.Count >= 0);
		}
		[TestMethod]
		public void SearchTest()
		{
			// Arrange
			ChildResourceRepository target = new ChildResourceRepository(_context);
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
			Assert.IsTrue(actual.Count >= 0);
		}

		[TestMethod]
		public void SearchWithoutPagingOrSortingTest()
		{
			// Arrange
			ChildResourceRepository target = new ChildResourceRepository(_context);
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
			Assert.IsTrue(actual.Count >= 0);
		}

		[TestMethod]
		public void SearchWithoutPagingSortedAscendingTest()
		{
			// Arrange
			ChildResourceRepository target = new ChildResourceRepository(_context);
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
			Assert.IsTrue(actual.Count >= 0);
		}

		[TestMethod]
		public void UpdateTest()
		{
			// Arrange
			ChildResourceRepository target = new ChildResourceRepository(_context);
			ChildResource expected = _mockdata.UpdateChildResource1();
			expected.Name = Guid.NewGuid().ToString();

			// Act
			ChildResource actual = target.Update(expected);

			// Assert
			Assert.AreEqual(expected.Name, actual.Name);
		}

		[TestMethod]
		public void UpdateNotFoundTest()
		{
			// Arrange
			ChildResourceRepository target = new ChildResourceRepository(_context);
			ChildResource expected = _mockdata.UpdateChildResource1();
			expected.Id = -1;
			expected.Name = Guid.NewGuid().ToString();

			// Act
			ChildResource actual = target.Update(expected);

			// Assert
			Assert.IsNull(actual);
		}

		[TestMethod]
		public void DeleteTest()
		{
			// Arrange
			ChildResourceRepository target = new ChildResourceRepository(_context);
			List<ChildResource> originalItems = _mockdata.GetAll();
			ChildResource expected = _mockdata.DeleteChildResource1();

			// Act
			target.Delete(expected.Id);
			List<ChildResource> updatedItems = target.ReadAll();

			// Assert
			Assert.AreNotEqual(originalItems.Count, updatedItems.Count);
		}

		[TestMethod]
		public void BuildQueryTest()
		{
			// Arrange
			ChildResourceRepository target = new ChildResourceRepository(_context);
			Type t = typeof(ChildResourceRepository);
			ChildResource expected = _mockdata.ChildResource1();
			ChildResourceSearchCriteria criteria = new ChildResourceSearchCriteria()
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
