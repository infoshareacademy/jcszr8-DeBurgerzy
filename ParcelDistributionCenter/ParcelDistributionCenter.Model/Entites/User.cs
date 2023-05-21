using Microsoft.AspNetCore.Identity;

namespace ParcelDistributionCenter.Model.Entites
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}