#region Using Statements
using Company.SampleApp.Domain.Client.Messages;
using Company.SampleApp.Domain.Models;
using Company.SampleApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
#endregion

namespace Company.SampleApp.Services.Core.Tests.RepositoryMocks
{
    public class ResourceRepositoryExceptionMock : IResourceRepository
    {
        public Resource Create(Resource entity)
        {
            throw new NotImplementedException();
        }

        public Resource Read(int id, string includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public List<Resource> ReadAll(string includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public PagingList<Resource> Search(ResourceSearchCriteria criteria, string includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public Resource Update(Resource entity)
        {
            throw new NotImplementedException();
        }
				
        public void Delete(int id, string includeProperties = null)
        {
            throw new NotImplementedException();
        }

    }
}
