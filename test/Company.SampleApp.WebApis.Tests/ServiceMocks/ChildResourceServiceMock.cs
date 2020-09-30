#region Using Statements
using Company.SampleApp.Domain.Client.Dtos;
using Company.SampleApp.Domain.Client.Messages;
using Company.SampleApp.Services.Interfaces;
using System.Collections.Generic;
#endregion

namespace Company.SampleApp.WebApis.Tests.ServiceMocks
{
    public class ChildResourceServiceMock : IChildResourceService
    {
        public string ErrorMessage { get; set; }

        public bool HasError
        {
            get { return !string.IsNullOrEmpty(this.ErrorMessage); }
        }

        public ChildResource Create(ChildResource entity)
        {
            entity.Id = 1;
            return entity;
        }

        public ChildResource Read(int id, string includeProperties = null)
        {
            if(id <= 0)
            {
                return null;
            }
            return new Domain.MockData.Client.Dtos.ChildResources().ChildResource1();
        }

        public List<ChildResource> ReadAll(string includeProperties = null)
        {
            return new Domain.MockData.Client.Dtos.ChildResources().GetAll();
        }

        public PagingList<ChildResource> Search(ChildResourceSearchCriteria criteria, string includeProperties = null)
        {
            return new PagingList<ChildResource>()
            {

            };
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
