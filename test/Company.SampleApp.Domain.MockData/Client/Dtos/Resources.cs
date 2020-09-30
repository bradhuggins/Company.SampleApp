#region Using Statements
using Company.SampleApp.Domain.Client.Dtos;
using System.Collections.Generic;
#endregion

namespace Company.SampleApp.Domain.MockData.Client.Dtos
{
    public class Resources
    {
        public List<Resource> SeedData()
        {
            List<Resource> entities = new List<Resource>();
            
            return entities;
        }

        public List<Resource> GetAll()
        {
            List<Resource> entities = new List<Resource>();
            entities.Add(this.Resource1());
            entities.Add(this.UpdateResource1());
            entities.Add(this.DeleteResource1());
            return entities;
        }

        public Resource NewResource()
        {
            Resource entity = new Resource();
            entity.Name = "New Mock Resource";
            return entity;
        }

        public Resource Resource1()
        {
            Resource entity = new Resource();
            entity.Id = 1001;
            entity.Name = "Mock Test Resource 1";
            return entity;
        }
        
        public Resource UpdateResource1()
        {
            Resource entity = new Resource();
            entity.Id = 1002;
            entity.Name = "Mock Update Test Resource 1";
            return entity;
        }

        public Resource DeleteResource1()
        {
            Resource entity = new Resource();
            entity.Id = 1003;
            entity.Name = "Mock Delete Test Resource 1";
            return entity;
        }

    }

}
