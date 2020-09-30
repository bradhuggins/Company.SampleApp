#region Using Statements
using Company.SampleApp.Domain.Client.Messages;
using Company.SampleApp.Domain.Models;
using System.Collections.Generic;
#endregion

namespace Company.SampleApp.Repositories.Interfaces
{
    public interface IResourceRepository
    {
        Resource Create(Resource entity);

        Resource Read(int id, string includeProperties = null);

        List<Resource> ReadAll(string includeProperties = null);

        PagingList<Resource> Search(ResourceSearchCriteria criteria, string includeProperties = null);

		Resource Update(Resource entity);

        void Delete(int id, string includeProperties = null);
        
    }
}