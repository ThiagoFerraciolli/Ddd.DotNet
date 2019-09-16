
using AutoMapper;
using Ddd.DotNet.Domain.Entities;
using Ddd.DotNet.MvcWebApi.ViewModels;

namespace Ddd.DotNet.MvcWebApi.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Client, ClientViewModel>();
        }
    }
}