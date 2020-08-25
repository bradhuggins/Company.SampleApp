#region Using Statements
using System;
using System.Collections.Generic;
using Company.SampleApp.Domain.Client.Messages;
using Company.SampleApp.Domain.Models;
using Company.SampleApp.Repositories.Interfaces;
#endregion

namespace Company.SampleApp.Services.Core.Tests.RepositoryMocks
{
    public class OtherResourceRepositoryMock : IOtherResourceRepository
    {
        public string ConnectionString { get; set; }

        public OtherResource Create(OtherResource entity)
        {
            entity.Id = 1;
            return entity;
        }

        public OtherResource Read(int id)
        {
            return new Domain.MockData.Models.OtherResources().OtherResource1();
        }

        public List<OtherResource> ReadAll()
        {
            return new Domain.MockData.Models.OtherResources().GetAll();
        }

        public List<OtherResource> Search(OtherResourceSearchCriteria criteria)
        {
            var entities = new Domain.MockData.Models.OtherResources().GetAll();
            var toReturn = new List<OtherResource>();
            foreach(var entity in entities)
            {
                toReturn.Add(entity);
            }
            //toReturn.TotalCount = entities.Count;
            return toReturn;
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
