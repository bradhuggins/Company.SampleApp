#region Using Statements
using System;
using System.Collections.Generic;
using Company.SampleApp.Domain.Client.Dtos;
using Company.SampleApp.Domain.Client.Messages;
#endregion

namespace Company.SampleApp.Services.Interfaces
{
    public interface IResourceService
    {
        string ErrorMessage { get; set; }

        bool HasError { get; }

        Resource Create(Resource entity);

        Resource Read(int id, string includeProperties = null);

        List<Resource> ReadAll(string includeProperties = null);

        PagingList<Resource> Search(ResourceSearchCriteria criteria, string includeProperties = null);

        Resource Update(Resource entity);

        void Delete(int id, string includeProperties = null);

    }

}
