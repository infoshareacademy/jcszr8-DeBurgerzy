using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ParcelDistributionCenter.Logic.Services;
using ParcelDistributionCenter.Logic.Services.IServices;
using ParcelDistributionCenter.Logic.Validators;
using ParcelDistributionCenter.Model.Context;
using ParcelDistributionCenter.Model.Context.Memory;
using ParcelDistributionCenter.Model.Repositories;
using ParcelDistributionCenter.Web.ViewModels;

namespace ParcelDistributionCenter.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ParcelDistributionCenterContext>(opts =>
            opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("ParcelDistributionCenter.Web")));
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddControllersWithViews();
            // TODO: Wywaliæ MemoryRepository z DependencyInjection i wsadziæ ca³e do Seeda (¿eby nie zajmowa³o
            // pamiêci niepotrzebnie przez okres dzia³ania ca³ego programu
            builder.Services.AddSingleton<IMemoryRepository>(MemoryRepository.LoadData());
            builder.Services.AddScoped<IAddNewPackageService, AddNewPackageService>();
            builder.Services.AddScoped<IPackageService, PackageService>();
            builder.Services.AddScoped<IPackageValidator, PackageValidator>();
            builder.Services.AddTransient<IAddNewCourierService, AddNewCourierService>();
            builder.Services.AddTransient<ICourierService, CourierService>();
            builder.Services.AddTransient<IPackageServices, PackageServices>();
            builder.Services.AddTransient<IDeliveryMachinesService, DeliveryMachinesService>();
            builder.Services.AddAutoMapper(typeof(DeliveryMachineViewModel));
            var app = builder.Build();
            CreateDbIfNotExists(app);



            var mapper = (IMapper)app.Services.GetRequiredService(typeof(IMapper));
            mapper.ConfigurationProvider.AssertConfigurationIsValid();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "/{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

        private static void CreateDbIfNotExists(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var memoryRepository = services.GetRequiredService<IMemoryRepository>();
                var context = services.GetRequiredService<ParcelDistributionCenterContext>();
                Seed seed = new(memoryRepository);
                seed.Initialize(context);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred creating the DB.");
            }
        }
    }
}