using ParcelDistributionCenter.Logic.Services.IServices;
using ParcelDistributionCenter.Model.Entites;
using ParcelDistributionCenter.Model.Repositories;

namespace ParcelDistributionCenter.Logic.Services
{
    // TODO: Prevent code from nullable ids coming form json
    public class DeliveryMachinesService : IDeliveryMachinesService
    {
        private readonly IRepository<DeliveryMachine> _deliveryMachineRepository;
        private readonly IRepository<Package> _packageRepository;

        public DeliveryMachinesService(IRepository<DeliveryMachine> deliveryMachineRepository, IRepository<Package> packageRepository)
        {
            _deliveryMachineRepository = deliveryMachineRepository;
            _packageRepository = packageRepository;
        }

        public void AssignPackage(string packageNumber, string deliveryMachineId)
        {
            Package package = _packageRepository.GetAll().First(p => p.PackageNumber == int.Parse(packageNumber));
            DeliveryMachine deliveryMachine = FindDeliveryMachineById(deliveryMachineId);
            switch (package.Size)
            {
                case Model.Enums.PackageSize.Big:
                    deliveryMachine.BigLockersCount -= 1;
                    break;

                case Model.Enums.PackageSize.Medium:
                    deliveryMachine.MediumLockersCount -= 1;
                    break;

                case Model.Enums.PackageSize.Small:
                    deliveryMachine.SmallLockersCount -= 1;
                    break;
            }
            package.DeliveryMachineId = deliveryMachineId;
            _packageRepository.Update(package);
            _deliveryMachineRepository.Update(deliveryMachine);
        }

        public void CreateNewDeliveryMachine(DeliveryMachine deliveryMachine) => _deliveryMachineRepository.Insert(deliveryMachine);

        public bool DeleteDeliveryMachineById(string deliveryMachineId)
        {
            DeliveryMachine deliveryMachine = FindDeliveryMachineById(deliveryMachineId);
            if (deliveryMachine != null)
            {
                _deliveryMachineRepository.Delete(deliveryMachine);
                return true;
            }
            return false;
        }

        public IEnumerable<DeliveryMachine> GetAll() => _deliveryMachineRepository.GetAll(d => d.Packages);

        public DeliveryMachine GetDeliveryMachineById(string id) => FindDeliveryMachineById(id);

        public IEnumerable<Package> GetDeliveryMachinePackages(string deliveryMachineId) => _packageRepository.GetAll().Where(p => p.DeliveryMachineId == deliveryMachineId);

        public IEnumerable<Package> GetDeliveryMachineUnassignedPackages() => _packageRepository.GetAll().Where(p => p.DeliveryMachineId == null);

        public void UnassignPackage(string packageNumber, string deliveryMachineId)
        {
            Package package = _packageRepository.GetAll().First(p => p.PackageNumber == int.Parse(packageNumber));
            DeliveryMachine deliveryMachine = FindDeliveryMachineById(deliveryMachineId);
            switch (package.Size)
            {
                case Model.Enums.PackageSize.Big:
                    deliveryMachine.BigLockersCount += 1;
                    break;

                case Model.Enums.PackageSize.Medium:
                    deliveryMachine.MediumLockersCount += 1;
                    break;

                case Model.Enums.PackageSize.Small:
                    deliveryMachine.SmallLockersCount += 1;
                    break;
            }
            package.DeliveryMachineId = null;
            _packageRepository.Update(package);
            _deliveryMachineRepository.Update(deliveryMachine);
        }

        public void UpdateDeliveryMachine(DeliveryMachine deliveryMachine) => _deliveryMachineRepository.Update(deliveryMachine);

        private DeliveryMachine FindDeliveryMachineById(string deliveryMachineId) => _deliveryMachineRepository.Get(deliveryMachineId, d => d.Packages);
    }
}