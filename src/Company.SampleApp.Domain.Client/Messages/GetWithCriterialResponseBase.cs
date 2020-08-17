#region Using Statements
using System.Collections.Generic;
using System.Runtime.Serialization;
#endregion

namespace Company.SampleApp.Domain.Client.Messages
{
    [DataContract]
    public abstract class GetWithCriteriaResponseBase<T> where T : class
    {
		[DataMember]
        public string ErrorMessage { get; set; }

        [DataMember]
        public bool HasError 
        {
            get { return !string.IsNullOrEmpty(this.ErrorMessage); }
            private set { bool result = value; } 
        }

        [DataMember]
        public List<T> Results { get; set; }

        [DataMember]
        public int TotalCount { get; set; }
		
    }

}
