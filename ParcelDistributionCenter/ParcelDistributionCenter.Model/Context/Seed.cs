using Microsoft.AspNetCore.Identity;
using ParcelDistributionCenter.Model.Context.JsonReaderService;
using ParcelDistributionCenter.Model.Entites;
using ParcelDistributionCenter.Model.Enums;

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
            if (context.Couriers.Any() &&
                context.Users.Any() &&
                context.Packages.Any() &&
                context.ReportPackages.Any() &&
                context.DeliveryMachines.Any())
            {
                return;
            }
            AddDataFromJsonFiles(context);
            GenerateReportPackages(context);
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

        private static void GenerateReportPackages(ParcelDistributionCenterContext context)
        {
            Random random = new();
            for (int i = 0; i < 20; i++)
            {
                var addingDuration = random.Next(10, 61);
                var timeCreated = DateTime.Now.AddDays(-i).AddHours(i ^ 2).AddMinutes(i ^ 3).AddSeconds(i ^ 4);
                ReportPackage reportPackage = new()
                {
                    AddingDurationInSeconds = addingDuration,
                    Size = (PackageSize)random.Next(0, 3),
                    TimeCreated = timeCreated,
                };
                context.ReportPackages.Add(reportPackage);
            }
        }

        private async Task AddUsersAndRoles(ParcelDistributionCenterContext context)
        {
            // Creating roles
            IdentityRole adminRole = new(AdminRole);
            IdentityRole commonUserRole = new(CommonUserRole);
            await _roleManager.CreateAsync(adminRole);
            await _roleManager.CreateAsync(commonUserRole);

            // Creating users
            User michalPietrzakAdminUser = new()
            {
                FirstName = "Michal",
                LastName = "Pietrzak",
                Email = "mp@wp.pl",
                UserName = "mp@wp.pl",
            };
            User maciejDuszaAdminUser = new()
            {
                FirstName = "Maciej",
                LastName = "Dusza",
                Email = "md@wp.pl",
                UserName = "md@wp.pl",
            };
            User szymonGrzędaAdminUser = new()
            {
                FirstName = "Szymon",
                LastName = "Grzeda",
                Email = "sg@wp.pl",
                UserName = "sg@wp.pl",
            };
            User commonUser_1 = new()
            {
                FirstName = "Patryk",
                LastName = "Waclawski",
                Email = "pw@wp.pl",
                UserName = "pw@wp.pl",
            };
            User commonUser_2 = new()
            {
                FirstName = "Monika",
                LastName = "Winiecka",
                Email = "mw@wp.pl",
                UserName = "mw@wp.pl"
            };
            User commonUser_3 = new()
            {
                FirstName = "Klauida",
                LastName = "Sonacka",
                Email = "ks@wp.pl",
                UserName = "ks@wp.pl"
            };

            await _userManager.CreateAsync(michalPietrzakAdminUser, defaultPassword);
            await _userManager.CreateAsync(maciejDuszaAdminUser, defaultPassword);
            await _userManager.CreateAsync(szymonGrzędaAdminUser, defaultPassword);
            await _userManager.CreateAsync(commonUser_1, defaultPassword);
            await _userManager.CreateAsync(commonUser_2, defaultPassword);
            await _userManager.CreateAsync(commonUser_3, defaultPassword);

            // Adding roles to users
            await _userManager.AddToRoleAsync(michalPietrzakAdminUser, AdminRole);
            await _userManager.AddToRoleAsync(maciejDuszaAdminUser, AdminRole);
            await _userManager.AddToRoleAsync(szymonGrzędaAdminUser, AdminRole);
            await _userManager.AddToRoleAsync(commonUser_1, CommonUserRole);
            await _userManager.AddToRoleAsync(commonUser_2, CommonUserRole);
            await _userManager.AddToRoleAsync(commonUser_3, CommonUserRole);
        }
    }
}