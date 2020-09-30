#region Using Statements
using System.Collections.Generic;
#endregion

namespace Company.SampleApp.Domain.Client.Messages
{
    public abstract class GetWithCriteriaResponseBase<T> where T : class
    {
        public string ErrorMessage { get; set; }

        public bool HasError 
        {
            get { return !string.IsNullOrEmpty(this.ErrorMessage); }
            private set { bool result = value; } 
        }

        public List<T> Results { get; set; }

        public int TotalCount { get; set; }
		
    }

}
