namespace ParcelDistributionCenter.Web.ViewModels
{
    public class CourierViewModel
    {
        public string CourierId { get; init; }
     
        public string Email { get; set; }
   
        public string Name { get; set; }
    
        public string Phone { get; set; }

        public string Surname { get; set; }
        
        //public ICollection<Package> Packages { get; set; } = new List<Package>();
    }
}
