using AutoMapper;
using ParcelDistributionCenter.Logic.ViewModels;
using ParcelDistributionCenter.Model.Entites;

namespace ParcelDistributionCenter.Web.AutoMapper
{
    public class ParcelDistributionCenterProfile : Profile
    {
        public ParcelDistributionCenterProfile()
        {
            CreateMap<DeliveryMachineViewModel, DeliveryMachine>()
                .ForMember(dest => dest.DeliveryMachineJsonId, opt => opt.Ignore())
                .ForMember(dest => dest.TimeCreated, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<PackageViewModel, Package>(MemberList.Source)
                //.ForMember(dest => dest.Registered, opt => opt.Ignore())
                .ReverseMap();

            //CreateMap<Package, PackageViewModel>();

            CreateMap<Courier, CourierViewModel>()
                 .ForMember(dest => dest.CourierId, opt => opt.MapFrom(src => src.Id))
                 .ReverseMap();
        }
    }
}