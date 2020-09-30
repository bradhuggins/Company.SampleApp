#region Using Statements
using Company.SampleApp.Domain.Client.Dtos;
using Company.SampleApp.Domain.Client.Messages;
using System.Collections.Generic;
#endregion

namespace Company.SampleApp.Services.Interfaces
{
    public interface IChildResourceService
    {
        string ErrorMessage { get; set; }

        bool HasError { get; }

        ChildResource Create(ChildResource entity);

        ChildResource Read(int id, string includeProperties = null);

        List<ChildResource> ReadAll(string includeProperties = null);

        PagingList<ChildResource> Search(ChildResourceSearchCriteria criteria, string includeProperties = null);

        ChildResource Update(ChildResource entity);

        void Delete(int id, string includeProperties = null);

    }

}
