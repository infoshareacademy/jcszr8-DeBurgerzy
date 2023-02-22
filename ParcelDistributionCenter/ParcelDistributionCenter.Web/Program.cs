using ParcelDistributionCenter.Logic;
using ParcelDistributionCenter.Logic.Services;

namespace ParcelDistributionCenter.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSingleton<IMemoryRepository, MemoryRepository>();
            builder.Services.AddTransient<IAddNewPackageHandler, AddNewPackageHandler>();
            builder.Services.AddTransient<IPackageHandler, PackageHandler>();
            builder.Services.AddTransient<ICourierHandler, CourierHandler>();
            builder.Services.AddTransient<IPackageServices, PackageServices > ();

            var app = builder.Build();

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}