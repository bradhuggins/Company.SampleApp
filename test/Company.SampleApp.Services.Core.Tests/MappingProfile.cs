#region Using Statements
using AutoMapper;
#endregion

namespace Company.SampleApp.Services.Core.Tests
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
					CreateMap<Domain.Models.ChildResource, Domain.Client.Dtos.ChildResource>();
					CreateMap<Domain.Client.Dtos.ChildResource, Domain.Models.ChildResource>();
					CreateMap<Domain.Models.Resource, Domain.Client.Dtos.Resource>();
					CreateMap<Domain.Client.Dtos.Resource, Domain.Models.Resource>();

        }
    }

}
