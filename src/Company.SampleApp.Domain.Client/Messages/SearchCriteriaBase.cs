#region Using Statements
using System;
#endregion

namespace Company.SampleApp.Domain.Client.Messages
{
    public abstract class SearchCriteriaBase : ISearchCriteria
    {
        public string SortFieldName { get; set; }

        public Enumerations.SortDirection SortDirection { get; set; }

        public int PageNumber { get; set; }

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
