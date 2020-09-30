#region Using Statements
using Company.SampleApp.Domain.Client.Messages;
using Company.SampleApp.Domain.Models;
using Company.SampleApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
#endregion

namespace Company.SampleApp.Services.Core.Tests.RepositoryMocks
{
    public class OtherResourceRepositoryExceptionMock : IOtherResourceRepository
    {
        public string ConnectionString { get; set; }

        public OtherResource Create(OtherResource entity)
        {
            throw new NotImplementedException();
        }

        public OtherResource Read(int id)
        {
            throw new NotImplementedException();
        }

        public List<OtherResource> ReadAll()
        {
            throw new NotImplementedException();
        }

        public List<OtherResource> Search(OtherResourceSearchCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public OtherResource Update(OtherResource entity)
        {
            throw new NotImplementedException();
        }
				
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
