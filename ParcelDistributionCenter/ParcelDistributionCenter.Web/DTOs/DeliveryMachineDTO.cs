namespace ParcelDistributionCenter.Web.DTOs
{
    public class DeliveryMachineDTO
    {
        public string Address { get; set; }

        public int BigLockersCount { get; set; }

        // DO WYWALENIA PO TYM JAK Z DELIVERYMACHINE WYRZUCIMY KONSTRUKTOR
        public string DeliveryMachineId { get; init; }

        public bool IsActive { get; set; }

        public int MediumLockersCount { get; set; }

        public int SmallLockersCount { get; set; }
    }
}