#region Using Statements
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
#endregion

namespace Company.SampleApp.Domain.Client.Messages
{
    [DataContract]
    public partial class ChildResourceSearchCriteria : SearchCriteriaBase
    {
		public ChildResourceSearchCriteria()
        {
            PageNumber = 1;
            PageSize = 10;
            SortDirection = Domain.Client.Enumerations.SortDirection.Ascending;
            SortFieldName = "Name";
        }

		[DataMember]
		[Display(Name = "Id")]
        public int? Id { get; set; }	

        [DataMember]
		[Display(Name = "Name (starts with)")]
        public string NameStartsWith { get; set; }	

    }

}
