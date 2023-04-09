using AutoMapper;
using ParcelDistributionCenter.Model.Models;
using ParcelDistributionCenter.Web.DTOs;

namespace ParcelDistributionCenter.Web.AutoMapper
{
    public class DeliveryMachineProfile : Profile
    {
        public DeliveryMachineProfile()
        {
            CreateMap<DeliveryMachineDTO, DeliveryMachine>()
                .ForMember(dest => dest.DeliveryMachineId, opt => opt.Ignore());
        }
    }
}