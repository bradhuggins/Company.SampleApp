#region Using Statements
using System.Collections.Generic;
using System.Runtime.Serialization;
#endregion

namespace Company.SampleApp.Domain.Client.Messages
{
    public class PagingList<T> : List<T>
    {
        public PagingList() : base()
        {
        }

        //public PagingList(int capacity) : base(capacity)
        //{
        //}

        public PagingList(IEnumerable<T> collection) : base(collection)
        {
        }

        public int TotalCount { get; set; }
    }
}
