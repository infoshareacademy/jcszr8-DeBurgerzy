using AutoMapper;
using ParcelDistributionCenter.Logic.Models;
using ParcelDistributionCenter.Model.Models;
using ParcelDistributionCenter.Web.ViewModels;

namespace ParcelDistributionCenter.Web.AutoMapper
{
    public class ParcelDistributionCenterProfile : Profile
    {
        public ParcelDistributionCenterProfile()
        {
            CreateMap<DeliveryMachineViewModel, DeliveryMachine>()
                .ForMember(dest => dest.DeliveryMachineId, opt => opt.Ignore());

            CreateMap<PackageViewModel, Package>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TimeCreated, opt => opt.Ignore())
                .ForMember(dest => dest.CourierId, opt => opt.Ignore())
                .ForMember(dest => dest.DeliveryMachineId, opt => opt.Ignore())
                .ForMember(dest => dest.PackageNumber, opt => opt.Ignore())
                .ForMember(dest => dest.Registered, opt => opt.Ignore());
        }
    }
}