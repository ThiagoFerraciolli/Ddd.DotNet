using AutoMapper;
using Ddd.DotNet.Domain.Entities;
using Ddd.DotNet.MvcWebApi.ViewModels;

namespace Ddd.DotNet.MvcWebApi.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ClientViewModel, Client>();
        }

    }
}