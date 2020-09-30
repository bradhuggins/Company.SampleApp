#region Using Statements
using Company.SampleApp.Domain.Client.Dtos;
using Company.SampleApp.Domain.Client.Messages;
using Company.SampleApp.Services.Interfaces;
using System.Collections.Generic;
#endregion

namespace Company.SampleApp.WebApis.Tests.ServiceMocks
{
    public class OtherResourceServiceMock : IOtherResourceService
    {
        public string ErrorMessage { get; set; }

        public bool HasError
        {
            get { return !string.IsNullOrEmpty(this.ErrorMessage); }
        }

        public OtherResource Create(OtherResource entity)
        {
            entity.Id = 1;
            return entity;
        }

        public OtherResource Read(int id)
        {
            if(id <= 0)
            {
                return null;
            }
            return new Domain.MockData.Client.Dtos.OtherResources().OtherResource1();
        }

        public List<OtherResource> ReadAll()
        {
            return new Domain.MockData.Client.Dtos.OtherResources().GetAll();
        }

        public List<OtherResource> Search(OtherResourceSearchCriteria criteria)
        {
            return new List<OtherResource>()
            {

            };
        }

        public OtherResource Update(OtherResource entity)
        {
            return entity;
        }
		
        public void Delete(int id)
        {
            return;
        }

    }
}
