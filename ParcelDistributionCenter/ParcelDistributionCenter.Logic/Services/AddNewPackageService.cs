using AutoMapper;
using ParcelDistributionCenter.Logic.Services.IServices;
using ParcelDistributionCenter.Logic.ViewModels;
using ParcelDistributionCenter.Model.Entites;
using ParcelDistributionCenter.Model.Enums;
using ParcelDistributionCenter.Model.Repositories;

namespace ParcelDistributionCenter.Logic.Services
{
    public class AddNewPackageService : IAddNewPackageService
    {
        private readonly IRepository<Courier> _courierRepository;
        private readonly IRepository<DeliveryMachine> _deliverMachineRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<Package> _packageRepository;

        public AddNewPackageService(IRepository<Package> packageRepository, IMapper mapper, IRepository<Courier> courierRepository, IRepository<DeliveryMachine> deliverMachineRepository)
        {
            _packageRepository = packageRepository;
            _mapper = mapper;
            _courierRepository = courierRepository;
            _deliverMachineRepository = deliverMachineRepository;
        }

        public PackageViewModel AddNewPackage(PackageViewModel packageViewModel)
        {
            Package package = _mapper.Map<Package>(packageViewModel);
            package.PackageNumber = GeneratePackageNumber();
            package.CourierId = AssignCourierID();
            package.DeliveryMachineJsonId = AssignDeliveryMachineID(package.Size);
            _packageRepository.Insert(package);
            packageViewModel.PackageNumber = package.PackageNumber;
            return packageViewModel;
        }

        protected string AssignCourierID()
        {
            IEnumerable<string> courierIDs = _courierRepository.GetAll().Select(c => c.CourierJsonId);
            return GenerateRandomID(courierIDs);
        }

        private static string GenerateRandomID(IEnumerable<string> IdCollection)
        {
            Random rnd = new();
            int selectedIndex = rnd.Next(IdCollection.Count());
            return IdCollection.ToArray()[selectedIndex];
        }

        private string AssignDeliveryMachineID(PackageSize size)
        {
            IEnumerable<string> deliveryMachineIDs = _deliverMachineRepository.GetAll().Select(c => c.Id);
            string generatedId = GenerateRandomID(deliveryMachineIDs);
            DeliveryMachine deliveryMachine = _deliverMachineRepository.Get(generatedId);
            if (deliveryMachine != null)
            {
                switch (size)
                {
                    case PackageSize.Big:
                        if (deliveryMachine.BigLockersCount > 0)
                        {
                            return generatedId;
                        }
                        break;

                    case PackageSize.Medium:
                        if (deliveryMachine.MediumLockersCount > 0)
                        {
                            return generatedId;
                        }
                        break;

                    case PackageSize.Small:
                        if (deliveryMachine.SmallLockersCount > 0)
                        {
                            return generatedId;
                        }
                        break;
                }
            }
            return null;
        }

        private int GeneratePackageNumber()
        {
            IEnumerable<int> packagesNumbers = _packageRepository.GetAll().Select(c => c.PackageNumber);
            Random rnd = new();
            int generatedNumber;
            do
            {
                generatedNumber = rnd.Next(1_000_000, 10_000_000);
            } while (packagesNumbers.Contains(generatedNumber));
            return generatedNumber;
        }
    }
}