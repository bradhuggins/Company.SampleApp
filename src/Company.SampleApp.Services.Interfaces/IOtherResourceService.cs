#region Using Statements
using System;
using System.Collections.Generic;
using Company.SampleApp.Domain.Client.Dtos;
using Company.SampleApp.Domain.Client.Messages;
#endregion

namespace Company.SampleApp.Services.Interfaces
{
    public interface IOtherResourceService
    {
        string ErrorMessage { get; set; }

        bool HasError { get; }

        OtherResource Create(OtherResource entity);

        OtherResource Read(int id);

        List<OtherResource> ReadAll();

        List<OtherResource> Search(OtherResourceSearchCriteria criteria);

        OtherResource Update(OtherResource entity);

        void Delete(int id);

    }

}
