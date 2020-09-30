#region Using Statements
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
#endregion

namespace Company.SampleApp.Domain.Client.Messages
{
    public partial class ChildResourceSearchCriteria : SearchCriteriaBase
    {
		public ChildResourceSearchCriteria()
        {
            PageNumber = 1;
            PageSize = 10;
            SortDirection = Domain.Client.Enumerations.SortDirection.Ascending;
            SortFieldName = "Name";
        }

		[Display(Name = "Id")]
        public int? Id { get; set; }	

		[Display(Name = "Name (starts with)")]
        public string NameStartsWith { get; set; }	

    }

}
