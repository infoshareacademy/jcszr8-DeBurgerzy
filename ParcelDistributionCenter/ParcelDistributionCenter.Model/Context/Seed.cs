using ParcelDistributionCenter.Model.Context.Memory;
using ParcelDistributionCenter.Model.Entites;

namespace ParcelDistributionCenter.Model.Context
{
    public class Seed
    {
        private readonly IJsonReader _memoryRepository;

        public Seed(IJsonReader memoryRepository)
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

            List<Package> packages = _memoryRepository.PackagesList;
            foreach (Package package in packages)
            {
                context.Packages.Add(package);
            }

            List<Courier> couriers = _memoryRepository.CouriersList;
            foreach (Courier courier in couriers)
            {
                IEnumerable<Package> courierPackages = packages.Where(p => p.CourierJsonId == courier.CourierJsonId);
                foreach (Package courierPackage in courierPackages)
                {
                    courier.Packages.Add(courierPackage);
                }
                context.Couriers.Add(courier);
            }

            List<DeliveryMachine> deliveryMachines = _memoryRepository.DeliveryMachinesList;
            foreach (DeliveryMachine deliveryMachine in deliveryMachines)
            {
                IEnumerable<Package> deliveryMachinePackages = packages.Where(p => p.DeliveryMachineJsonId == deliveryMachine.DeliveryMachineJsonId);
                foreach (Package deliveryMachinePackage in deliveryMachinePackages)
                {
                    deliveryMachine.Packages.Add(deliveryMachinePackage);
                }
                context.DeliveryMachines.Add(deliveryMachine);
            }

            context.SaveChanges();
        }
    }
}