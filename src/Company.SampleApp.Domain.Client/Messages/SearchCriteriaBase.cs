#region Using Statements
using System;
using System.Runtime.Serialization;
#endregion

namespace Company.SampleApp.Domain.Client.Messages
{
    [DataContract]
    public abstract class SearchCriteriaBase : ISearchCriteria
    {
        [DataMember]
        public string SortFieldName { get; set; }
        [DataMember]
        public Enumerations.SortDirection SortDirection { get; set; }
        [DataMember]
        public int PageNumber { get; set; }
        [DataMember]
        public int PageSize { get; set; }

        public SearchCriteriaBase()
        {
            this.SortDirection = Enumerations.SortDirection.Descending;
            this.PageSize = 10;
            this.PageNumber = 1;
        }

        public virtual void UpdateCriteria(string sortFieldName, int pageNumber = 1)
        {
            SearchCriteriaBase criteria = this;
            if (!String.IsNullOrEmpty(sortFieldName))
            {
                if (sortFieldName == criteria.SortFieldName)
                {
                    if (criteria.SortDirection == Enumerations.SortDirection.Descending)
                    {
                        criteria.SortDirection = Enumerations.SortDirection.Ascending;
                    }
                }
            }

            //paging            
            if (pageNumber <= 0)
            {
                pageNumber = 1;
            }
            criteria.PageNumber = pageNumber;
            if (criteria.PageSize < 10)
            {
                criteria.PageSize = 10;
            }
        }
    }
}
