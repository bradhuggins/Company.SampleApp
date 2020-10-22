#region Using Statements
using System;
using System.Collections.Generic;
using Company.SampleApp.Domain.Client.Dtos;
using Company.SampleApp.Domain.Client.Messages;
using Company.SampleApp.Services.Interfaces;
#endregion

namespace Company.SampleApp.WebApis.Tests.ServiceMocks
{
    public class ResourceServiceMock : IResourceService
    {
        public string ErrorMessage { get; set; }

        public bool HasError
        {
            get { return !string.IsNullOrEmpty(this.ErrorMessage); }
        }

        public Resource Create(Resource entity)
        {
            entity.Id = 1;
            return entity;
        }

        public Resource Read(int id, string includeProperties = null)
        {
            if(id <= 0)
            {
                return null;
            }
            return new Domain.MockData.Client.Dtos.Resources().Resource1();
        }

        public List<Resource> ReadAll(string includeProperties = null)
        {
            return new Domain.MockData.Client.Dtos.Resources().GetAll();
        }

        public PagingList<Resource> Search(ResourceSearchCriteria criteria, string includeProperties = null)
        {
            return new PagingList<Resource>()
            {

            };
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
