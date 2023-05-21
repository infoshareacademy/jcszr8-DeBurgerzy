using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ParcelDistributionCenter.Logic.Services;
using ParcelDistributionCenter.Logic.Services.IServices;
using ParcelDistributionCenter.Model.Context;
using ParcelDistributionCenter.Model.Repositories;

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
            builder.Services.AddScoped<IAddNewPackageService, AddNewPackageService>();
            builder.Services.AddScoped<IPackageService, PackageService>();
            builder.Services.AddTransient<ICourierService, CourierService>();
            builder.Services.AddTransient<IDeliveryMachinesService, DeliveryMachinesService>();
            builder.Services.AddAutoMapper(typeof(Program));

            // Add HTTP Client
            builder.Services.AddHttpClient<IReportService, ReportService>(config =>
            {
                string baseAddress = builder.Configuration["ApiSettings:BaseUrl"];
                config.BaseAddress = new Uri(baseAddress);
            });

            var app = builder.Build();
            CreateDbIfNotExists(app);

            // Check AutoMapper configuration
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
                var context = services.GetRequiredService<ParcelDistributionCenterContext>();
                Seed seed = new();
                Seed.Initialize(context);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred creating the DB.");
            }
        }
    }
}