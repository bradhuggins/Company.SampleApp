#region Using Statements
using Company.SampleApp.Domain.Client.Messages;
using Company.SampleApp.Domain.Models;
using System.Collections.Generic;
#endregion

namespace Company.SampleApp.Repositories.Interfaces
{
    public interface IChildResourceRepository
    {
        ChildResource Create(ChildResource entity);

        ChildResource Read(int id, string includeProperties = null);

        List<ChildResource> ReadAll(string includeProperties = null);

        PagingList<ChildResource> Search(ChildResourceSearchCriteria criteria, string includeProperties = null);

		ChildResource Update(ChildResource entity);

        void Delete(int id, string includeProperties = null);
        
    }
}