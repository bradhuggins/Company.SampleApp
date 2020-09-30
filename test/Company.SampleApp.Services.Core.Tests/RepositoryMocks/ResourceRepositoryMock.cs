#region Using Statements
using Company.SampleApp.Domain.Client.Messages;
using Company.SampleApp.Domain.Models;
using Company.SampleApp.Repositories.Interfaces;
using System.Collections.Generic;
#endregion

namespace Company.SampleApp.Services.Core.Tests.RepositoryMocks
{
    public class ResourceRepositoryMock : IResourceRepository
    {
        public Resource Create(Resource entity)
        {
            entity.Id = 1;
            return entity;
        }

        public Resource Read(int id, string includeProperties = null)
        {
            return new Domain.MockData.Models.Resources().Resource1();
        }

        public List<Resource> ReadAll(string includeProperties = null)
        {
            return new Domain.MockData.Models.Resources().GetAll();
        }

        public PagingList<Resource> Search(ResourceSearchCriteria criteria, string includeProperties = null)
        {
            var entities = new Domain.MockData.Models.Resources().GetAll();
            var toReturn = new PagingList<Resource>();
            foreach(var entity in entities)
            {
                toReturn.Add(entity);
            }
            toReturn.TotalCount = entities.Count;
            return toReturn;
        }

        public Resource Update(Resource entity)
        {
            return entity;
        }
				
        public void Delete(int id, string includeProperties = null)
        {
            return;
        }

    }
}
