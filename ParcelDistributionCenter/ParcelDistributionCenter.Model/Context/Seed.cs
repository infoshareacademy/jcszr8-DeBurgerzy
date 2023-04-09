using ParcelDistributionCenter.Model.Context.Memory;
using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.Model.Context
{
    public class Seed
    {
        private readonly IMemoryRepository _memoryRepository;

        public Seed(IMemoryRepository memoryRepository)
        {
            _memoryRepository = memoryRepository;
        }

        public void Initialize(ParcelDistributionCenterContext context)
        {
            context.Database.EnsureCreated();
            if (context.Couriers.Any())
            {
                return;
            }

            List<Courier> couriers = _memoryRepository.CouriersList;
            foreach (Courier courier in couriers)
            {
                context.Couriers.Add(courier);
            }

            List<DeliveryMachine> deliveryMachines = _memoryRepository.DeliveryMachinesList;
            foreach (DeliveryMachine deliveryMachine in deliveryMachines)
            {
                context.DeliveryMachines.Add(deliveryMachine);
            }

            List<Package> packages = _memoryRepository.PackagesList;
            foreach (Package package in packages)
            {
                context.Packages.Add(package);
            }

            context.SaveChanges();
        }
    }
}