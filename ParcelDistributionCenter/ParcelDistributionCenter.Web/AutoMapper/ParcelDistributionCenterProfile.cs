using AutoMapper;
using ParcelDistributionCenter.Model.Entites;
using ParcelDistributionCenter.Web.ViewModels;

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

            CreateMap<PackageViewModel, Package>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TimeCreated, opt => opt.Ignore())
                .ForMember(dest => dest.CourierId, opt => opt.Ignore())
                .ForMember(dest => dest.DeliveryMachineJsonId, opt => opt.Ignore())
                .ForMember(dest => dest.CourierJsonId, opt => opt.Ignore())
                .ForMember(dest => dest.Courier, opt => opt.Ignore())
                .ForMember(dest => dest.DeliveryMachine, opt => opt.Ignore());

            CreateMap<Package, PackageViewModel>();

            CreateMap<Courier, CourierViewModel>()
                 .ForMember(dest => dest.CourierId, opt => opt.MapFrom(src => src.Id))
                 .ReverseMap();
        }
    }
}