using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ParcelDistributionCenter.Logic.Services;
using ParcelDistributionCenter.Logic.Services.IServices;
using ParcelDistributionCenter.Model.Context;
using ParcelDistributionCenter.Model.Entites;
using ParcelDistributionCenter.Model.Repositories;
using Serilog;

namespace ParcelDistributionCenter.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(config).CreateLogger();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSerilog();
            builder.Services.AddDbContext<ParcelDistributionCenterContext>(opts =>
                                          opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                                          b => b.MigrationsAssembly("ParcelDistributionCenter.Web")));
            builder.Services.AddDefaultIdentity<User>(/*options => options.SignIn.RequireConfirmedAccount = true*/)
                            .AddRoles<IdentityRole>()
                            .AddEntityFrameworkStores<ParcelDistributionCenterContext>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IAddNewPackageService, AddNewPackageService>();
            builder.Services.AddScoped<IPackageService, PackageService>();
            builder.Services.AddSingleton<IEmailService, EmailService>();
            builder.Services.AddTransient<ICourierService, CourierService>();
            builder.Services.AddTransient<IDeliveryMachinesService, DeliveryMachinesService>();
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddScoped<Seed>();

            // Add HTTP Client
            builder.Services.AddHttpClient<IReportService, ReportService>(config =>
            {
                string baseAddress = builder.Configuration["ApiSettings:BaseUrl"];
                config.BaseAddress = new Uri(baseAddress);
            });

            var app = builder.Build();
            await CreateDbIfNotExists(app);

            IEmailService emailSender = (IEmailService)app.Services.GetRequiredService(typeof(IEmailService));
            await emailSender.StartSendingEmails();

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "/{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }

        private static async Task CreateDbIfNotExists(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<ParcelDistributionCenterContext>();
                Seed seed = services.GetRequiredService<Seed>();
                await seed.Initialize(context);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred creating the DB.");
            }
        }
    }
}