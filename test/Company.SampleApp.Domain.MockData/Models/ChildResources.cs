#region Using Statements
using Company.SampleApp.Domain.Models;
using System;
using System.Collections.Generic; 
#endregion

namespace Company.SampleApp.Domain.MockData.Models
{
    public class ChildResources
    {
        public List<ChildResource> SeedData()
        {
            List<ChildResource> entities = new List<ChildResource>();
            
            return entities;
        }

        public List<ChildResource> GetAll()
        {
            List<ChildResource> entities = new List<ChildResource>();
            entities.Add(this.ChildResource1());
            entities.Add(this.UpdateChildResource1());
            entities.Add(this.DeleteChildResource1());
            return entities;
        }

        public ChildResource NewChildResource()
        {
            ChildResource entity = new ChildResource();
            entity.Name = "New Mock ChildResource";
            return entity;
        }

        public ChildResource ChildResource1()
        {
            ChildResource entity = new ChildResource();
            entity.Id = 1001;
            entity.Name = "Mock Test ChildResource 1";
            return entity;
        }
        
        public ChildResource UpdateChildResource1()
        {
            ChildResource entity = new ChildResource();
            entity.Id = 1002;
            entity.Name = "Mock Update Test ChildResource 1";
            return entity;
        }

        public ChildResource DeleteChildResource1()
        {
            ChildResource entity = new ChildResource();
            entity.Id = 1003;
            entity.Name = "Mock Delete Test ChildResource 1";
            return entity;
        }

    }

}
