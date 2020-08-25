#region Using Statements
using System;
using System.Runtime.Serialization;
#endregion

namespace Company.SampleApp.Domain.Client.Dtos
{
	[DataContract]
    public partial class OtherResource
    {
		[DataMember]
        public int Id { get; set; }

		[DataMember]
        public string Name { get; set; }

    }

}
