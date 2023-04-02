using Microsoft.EntityFrameworkCore;
using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.Model.Context
{
    public class ParcelDistributionCenterContext : DbContext
    {
        public ParcelDistributionCenterContext(DbContextOptions<ParcelDistributionCenterContext> options) : base(options)
        {
        }

        public DbSet<Courier> Couriers { get; set; }
        public DbSet<DeliveryMachine> DeliveryMachines { get; set; }
        public DbSet<Package> Packages { get; set; }

        // TODO: TO BE CHANGED
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}