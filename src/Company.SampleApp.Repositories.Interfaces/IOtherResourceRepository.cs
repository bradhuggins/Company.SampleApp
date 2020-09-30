#region Using Statements
using Company.SampleApp.Domain.Client.Messages;
using Company.SampleApp.Domain.Models;
using System.Collections.Generic;
#endregion

namespace Company.SampleApp.Repositories.Interfaces
{
    public interface IOtherResourceRepository
    {
        string ConnectionString { get; set; }

        OtherResource Create(OtherResource entity);

        OtherResource Read(int id);

        List<OtherResource> ReadAll();

        List<OtherResource> Search(OtherResourceSearchCriteria criteria);

		OtherResource Update(OtherResource entity);

        void Delete(int id);
        
    }
}