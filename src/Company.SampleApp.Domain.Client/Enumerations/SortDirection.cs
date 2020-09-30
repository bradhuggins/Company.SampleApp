#region Using Statements
using System.Runtime.Serialization;
#endregion

namespace Company.SampleApp.Domain.Client.Enumerations
{
    public enum SortDirection
    {
        [EnumMember(Value = "Asc")]
        Ascending,

        [EnumMember(Value = "Desc")]
        Descending
    }
}
