using ParcelDistributionCenter.Model.Entites;

namespace ParcelDistributionCenter.Web.ViewModels
{
    public class DeliveryMachineViewModel
    {
        public string Address { get; set; }

        public int BigLockersCount { get; set; }

        public Courier Courier { get; set; }

        public string Id { get; set; }

        public bool IsActive { get; set; }

        public int MediumLockersCount { get; set; }

        public ICollection<Package> Packages { get; set; }

        public int SmallLockersCount { get; set; }
    }
}