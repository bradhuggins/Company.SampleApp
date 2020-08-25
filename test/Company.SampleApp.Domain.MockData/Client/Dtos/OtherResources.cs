#region Using Statements
using Company.SampleApp.Domain.Client.Dtos;
using System;
using System.Collections.Generic; 
#endregion

namespace Company.SampleApp.Domain.MockData.Client.Dtos
{
    public class OtherResources
    {
        public List<OtherResource> SeedData()
        {
            List<OtherResource> entities = new List<OtherResource>();
            
            return entities;
        }

        public List<OtherResource> GetAll()
        {
            List<OtherResource> entities = new List<OtherResource>();
            entities.Add(this.OtherResource1());
            entities.Add(this.UpdateOtherResource1());
            entities.Add(this.DeleteOtherResource1());
            return entities;
        }

        public OtherResource NewOtherResource()
        {
            OtherResource entity = new OtherResource();
            entity.Name = "New Mock OtherResource";
            return entity;
        }

        public OtherResource OtherResource1()
        {
            OtherResource entity = new OtherResource();
            entity.Id = 1001;
            entity.Name = "Mock Test OtherResource 1";
            return entity;
        }
        
        public OtherResource UpdateOtherResource1()
        {
            OtherResource entity = new OtherResource();
            entity.Id = 1002;
            entity.Name = "Mock Update Test OtherResource 1";
            return entity;
        }

        public OtherResource DeleteOtherResource1()
        {
            OtherResource entity = new OtherResource();
            entity.Id = 1003;
            entity.Name = "Mock Delete Test OtherResource 1";
            return entity;
        }

    }

}
