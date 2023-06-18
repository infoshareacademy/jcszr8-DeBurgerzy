using AutoMapper;
using ParcelDistributionCenter.Logic.ViewModels;
using ParcelDistributionCenter.Model.DTOs;
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

            CreateMap<Courier, CourierViewModel>()
                 .ForMember(dest => dest.CourierId, opt => opt.MapFrom(src => src.Id))
                 .ReverseMap();
            CreateMap<ReportPackageDto, ReportPackage>()
                 .ForMember(dest => dest.Id, opt => opt.Ignore())
                 .ReverseMap();
        }
    }
}