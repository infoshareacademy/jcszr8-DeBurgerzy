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
                .ReverseMap();

            CreateMap<UnassignedPackageViewModel, Package>(MemberList.Source);
            //.ForMember(dest => dest.Courier, opt => opt.MapFrom(src => src.CourierEmail))
            //.ForMember(dest => dest.DeliveryMachine, opt => opt.MapFrom(src => src.DeliveryMachineAddress));

            CreateMap<Courier, CourierViewModel>()
                 .ForMember(dest => dest.CourierId, opt => opt.MapFrom(src => src.Id))
                 .ReverseMap();
        }
    }
}