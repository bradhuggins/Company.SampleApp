#region Using Statements
using System;
using System.Collections.Generic;
using Company.SampleApp.Domain.Client.Dtos;
using Company.SampleApp.Domain.Client.Messages;
using Company.SampleApp.Services.Interfaces;
#endregion

namespace Company.SampleApp.WebApis.Tests.ServiceMocks
{
public class ChildResourceServiceExceptionMock : IChildResourceService
    {
        public string ErrorMessage { get; set; }

        public bool HasError
        {
            get { return !string.IsNullOrEmpty(this.ErrorMessage); }
        }

        public ChildResource Create(ChildResource entity)
        {
            this.ErrorMessage = "error";
            return null;
        }

        public ChildResource Read(int  id, string includeProperties = null)
        {
            this.ErrorMessage = "error";
            return null;
        }

        public List<ChildResource> ReadAll(string includeProperties = null)
        {
            this.ErrorMessage = "error";
            return null;
        }

        public PagingList<ChildResource> Search(ChildResourceSearchCriteria criteria, string includeProperties = null)
        {
            this.ErrorMessage = "error";
            return null;
        }

        public ChildResource Update(ChildResource entity)
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
