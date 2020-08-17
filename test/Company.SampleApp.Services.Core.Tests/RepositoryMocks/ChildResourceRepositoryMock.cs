#region Using Statements
using System;
using System.Collections.Generic;
using Company.SampleApp.Domain.Client.Messages;
using Company.SampleApp.Domain.Models;
using Company.SampleApp.Repositories.Interfaces;
#endregion

namespace Company.SampleApp.Services.Core.Tests.RepositoryMocks
{
    public class ChildResourceRepositoryMock : IChildResourceRepository
    {
        public ChildResource Create(ChildResource entity)
        {
            entity.Id = 1;
            return entity;
        }

        public ChildResource Read(int id, string includeProperties = null)
        {
            return new Domain.MockData.Models.ChildResources().ChildResource1();
        }

        public List<ChildResource> ReadAll(string includeProperties = null)
        {
            return new Domain.MockData.Models.ChildResources().GetAll();
        }

        public PagingList<ChildResource> Search(ChildResourceSearchCriteria criteria, string includeProperties = null)
        {
            var entities = new Domain.MockData.Models.ChildResources().GetAll();
            var toReturn = new PagingList<ChildResource>();
            foreach(var entity in entities)
            {
                toReturn.Add(entity);
            }
            toReturn.TotalCount = entities.Count;
            return toReturn;
        }

        public ChildResource Update(ChildResource entity)
        {
            return entity;
        }
				
        public void Delete(int id, string includeProperties = null)
        {
            return;
        }

    }
}
