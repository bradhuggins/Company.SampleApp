#region Using Statements
using System;
using System.Collections.Generic;
using Company.SampleApp.Domain.Client.Dtos;
using Company.SampleApp.Domain.Client.Messages;
using Company.SampleApp.Services.Interfaces;
#endregion

namespace Company.SampleApp.WebApis.Tests.ServiceMocks
{
public class OtherResourceServiceExceptionMock : IOtherResourceService
    {
        public string ErrorMessage { get; set; }

        public bool HasError
        {
            get { return !string.IsNullOrEmpty(this.ErrorMessage); }
        }

        public OtherResource Create(OtherResource entity)
        {
            this.ErrorMessage = "error";
            return null;
        }

        public OtherResource Read(int  id)
        {
            this.ErrorMessage = "error";
            return null;
        }

        public List<OtherResource> ReadAll()
        {
            this.ErrorMessage = "error";
            return null;
        }

        public List<OtherResource> Search(OtherResourceSearchCriteria criteria)
        {
            this.ErrorMessage = "error";
            return null;
        }

        public OtherResource Update(OtherResource entity)
        {
            this.ErrorMessage = "error";
            return null;
        }
		
        public void Delete(int  id)
        {
            this.ErrorMessage = "error";
        }

    }
}
