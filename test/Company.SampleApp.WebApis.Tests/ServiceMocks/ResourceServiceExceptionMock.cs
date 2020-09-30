#region Using Statements
using Company.SampleApp.Domain.Client.Dtos;
using Company.SampleApp.Domain.Client.Messages;
using Company.SampleApp.Services.Interfaces;
using System.Collections.Generic;
#endregion

namespace Company.SampleApp.WebApis.Tests.ServiceMocks
{
    public class ResourceServiceExceptionMock : IResourceService
    {
        public string ErrorMessage { get; set; }

        public bool HasError
        {
            get { return !string.IsNullOrEmpty(this.ErrorMessage); }
        }

        public Resource Create(Resource entity)
        {
            this.ErrorMessage = "error";
            return null;
        }

        public Resource Read(int  id, string includeProperties = null)
        {
            this.ErrorMessage = "error";
            return null;
        }

        public List<Resource> ReadAll(string includeProperties = null)
        {
            this.ErrorMessage = "error";
            return null;
        }

        public PagingList<Resource> Search(ResourceSearchCriteria criteria, string includeProperties = null)
        {
            this.ErrorMessage = "error";
            return null;
        }

        public Resource Update(Resource entity)
        {
            this.ErrorMessage = "error";
            return null;
        }
		
        public void Delete(int  id, string includeProperties = null)
        {
            this.ErrorMessage = "error";
        }

    }
}
