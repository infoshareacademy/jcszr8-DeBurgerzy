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
                .ForMember(dest => dest.DeliveryMachineJsonId, opt => opt.Ignore());

            CreateMap<PackageViewModel, Package>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TimeCreated, opt => opt.Ignore())
                .ForMember(dest => dest.CourierJsonId, opt => opt.Ignore())
                .ForMember(dest => dest.DeliveryMachineJsonId, opt => opt.Ignore())
                .ForMember(dest => dest.PackageNumber, opt => opt.Ignore())
                .ForMember(dest => dest.Registered, opt => opt.Ignore())
                // TODO: Delete this, ensure to be displayed in Views
                .ForMember(dest => dest.Courier, opt => opt.Ignore())
                // TODO: Delete this, ensure to be displayed in Views
                .ForMember(dest => dest.DeliveryMachine, opt => opt.Ignore());


            CreateMap<Courier, CourierViewModel>()
                 .ForMember(dest => dest.CourierId, opt => opt.MapFrom(src => src.CourierJsonId));
        }
    }
}