#region Using Statements
using Company.SampleApp.Domain.Client.Messages;
using Company.SampleApp.Domain.Models;
using Company.SampleApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
#endregion

namespace Company.SampleApp.Services.Core.Tests.RepositoryMocks
{
    public class ChildResourceRepositoryExceptionMock : IChildResourceRepository
    {
        public ChildResource Create(ChildResource entity)
        {
            throw new NotImplementedException();
        }

        public ChildResource Read(int id, string includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public List<ChildResource> ReadAll(string includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public PagingList<ChildResource> Search(ChildResourceSearchCriteria criteria, string includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public ChildResource Update(ChildResource entity)
        {
            throw new NotImplementedException();
        }
				
        public void Delete(int id, string includeProperties = null)
        {
            throw new NotImplementedException();
        }

    }
}
