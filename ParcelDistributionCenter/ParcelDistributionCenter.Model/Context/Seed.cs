using Microsoft.AspNetCore.Identity;
using ParcelDistributionCenter.Model.Context.JsonReaderService;
using ParcelDistributionCenter.Model.Entites;

namespace ParcelDistributionCenter.Model.Context
{
    public class Seed
    {
        private const string AdminRole = "Admin";
        private const string CommonUserRole = "CommonUser";
        private const string defaultPassword = "Admin123%";
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public Seed(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Initialize(ParcelDistributionCenterContext context)
        {
            context.Database.EnsureCreated();
            if (context.Couriers.Any())
            {
                return;
            }
            AddDataFromJsonFiles(context);
            await AddUsersAndRoles(context);
            context.SaveChanges();
        }

        private static void AddDataFromJsonFiles(ParcelDistributionCenterContext context)
        {
            JsonReader jsonReader = new();
            jsonReader.LoadData();

            List<Package> packages = jsonReader.PackagesList;
            foreach (Package package in packages)
            {
                context.Packages.Add(package);
            }

            List<Courier> couriers = jsonReader.CouriersList;
            foreach (Courier courier in couriers)
            {
                IEnumerable<Package> courierPackages = packages.Where(p => p.CourierJsonId == courier.CourierJsonId);
                foreach (Package courierPackage in courierPackages)
                {
                    courier.Packages.Add(courierPackage);
                }
                context.Couriers.Add(courier);
            }

            List<DeliveryMachine> deliveryMachines = jsonReader.DeliveryMachinesList;
            foreach (DeliveryMachine deliveryMachine in deliveryMachines)
            {
                IEnumerable<Package> deliveryMachinePackages = packages.Where(p => p.DeliveryMachineJsonId == deliveryMachine.DeliveryMachineJsonId);
                foreach (Package deliveryMachinePackage in deliveryMachinePackages)
                {
                    deliveryMachine.Packages.Add(deliveryMachinePackage);
                }
                context.DeliveryMachines.Add(deliveryMachine);
            }
        }

        private async Task AddUsersAndRoles(ParcelDistributionCenterContext context)
        {
            // Creating roles
            IdentityRole adminRole = new(AdminRole);
            IdentityRole commonUserRole = new(CommonUserRole);
            context.Roles.Add(adminRole);
            context.Roles.Add(commonUserRole);
            //await _roleManager.CreateAsync(adminRole);
            //await _roleManager.CreateAsync(commonUserRole);

            // Creating users
            User michalPietrzakAdminUser = new()
            {
                FirstName = "Michał",
                LastName = "Pietrzak",
                Email = "mp@wp.pl",
                //PasswordHash = defaultPassword
            };
            User maciejDuszaAdminUser = new()
            {
                FirstName = "Maciej",
                LastName = "Dusza",
                Email = "md@wp.pl",
                //PasswordHash = defaultPassword
            };
            User szymonGrzędaAdminUser = new()
            {
                FirstName = "Szymon",
                LastName = "Grzęda",
                Email = "sg@wp.pl",
                //PasswordHash = defaultPassword
            };
            User commonUser_1 = new()
            {
                FirstName = "Patryk",
                LastName = "Wącławski",
                Email = "pw@wp.pl",
                //PasswordHash = defaultPassword
            };
            User commonUser_2 = new()
            {
                FirstName = "Monika",
                LastName = "Winiecka",
                Email = "mw@wp.pl",
                //PasswordHash = defaultPassword
            };
            User commonUser_3 = new()
            {
                FirstName = "Klauida",
                LastName = "Sonacka",
                Email = "ks@wp.pl",
                //PasswordHash = defaultPassword
            };

            await _userManager.CreateAsync(michalPietrzakAdminUser, defaultPassword);
            context.Users.Add(michalPietrzakAdminUser);
            context.Users.Add(maciejDuszaAdminUser);
            context.Users.Add(szymonGrzędaAdminUser);
            context.Users.Add(commonUser_1);
            context.Users.Add(commonUser_2);
            context.Users.Add(commonUser_3);
            //await _userManager.CreateAsync(maciejDuszaAdminUser, defaultPassword);
            //await _userManager.CreateAsync(szymonGrzędaAdminUser, defaultPassword);
            //await _userManager.CreateAsync(commonUser_1, defaultPassword);
            //await _userManager.CreateAsync(commonUser_2, defaultPassword);
            //await _userManager.CreateAsync(commonUser_3, defaultPassword);

            context.SaveChanges();

            // Assigning roles to users
            context.UserRoles.Add(new IdentityUserRole<string>
            {
                UserId = michalPietrzakAdminUser.Id,
                RoleId = adminRole.Id
            });
            context.UserRoles.Add(new IdentityUserRole<string>
            {
                UserId = maciejDuszaAdminUser.Id,
                RoleId = adminRole.Id
            });
            context.UserRoles.Add(new IdentityUserRole<string>
            {
                UserId = szymonGrzędaAdminUser.Id,
                RoleId = adminRole.Id
            });

            context.UserRoles.Add(new IdentityUserRole<string>
            {
                UserId = commonUser_1.Id,
                RoleId = commonUserRole.Id
            });
            context.UserRoles.Add(new IdentityUserRole<string>
            {
                UserId = commonUser_2.Id,
                RoleId = commonUserRole.Id
            });
            context.UserRoles.Add(new IdentityUserRole<string>
            {
                UserId = commonUser_3.Id,
                RoleId = commonUserRole.Id
            });
            //await _userManager.AddToRoleAsync(michalPietrzakAdminUser, AdminRole);
            //await _userManager.AddToRoleAsync(maciejDuszaAdminUser, AdminRole);
            //await _userManager.AddToRoleAsync(szymonGrzędaAdminUser, AdminRole);
            //await _userManager.AddToRoleAsync(commonUser_1, CommonUserRole);
            //await _userManager.AddToRoleAsync(commonUser_2, CommonUserRole);
            //await _userManager.AddToRoleAsync(commonUser_3, CommonUserRole);
        }
    }
}