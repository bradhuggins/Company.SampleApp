#region Using Statements
#endregion

namespace Company.SampleApp.Domain.Client.Messages
{
    public interface ISearchCriteria
    {
        string SortFieldName { get; set; }

        Enumerations.SortDirection SortDirection { get; set; }

        int PageNumber { get; set; }

        int PageSize { get; set; }

    }
}
