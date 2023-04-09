namespace ParcelDistributionCenter.Web.ViewModels
{
    public class DeliveryMachineViewModel
    {
        public string Address { get; set; }

        public int BigLockersCount { get; set; }

        public string Id { get; set; }

        public bool IsActive { get; set; }

        public int MediumLockersCount { get; set; }

        public int SmallLockersCount { get; set; }

        public DateTime TimeCreated { get; set; } = DateTime.Now;
    }
}