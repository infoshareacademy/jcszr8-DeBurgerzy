using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ParcelDistributionCenter.Model.Entites;

namespace ParcelDistributionCenter.Model.Context
{
    public class ParcelDistributionCenterContext : IdentityDbContext<User>
    {
        public DbSet<Courier> Couriers { get; set; }
        public DbSet<DeliveryMachine> DeliveryMachines { get; set; }
        public DbSet<Package> Packages { get; set; }

        public ParcelDistributionCenterContext(DbContextOptions<ParcelDistributionCenterContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Package>()
                .HasOne(p => p.Courier)
                .WithMany(p => p.Packages)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Package>()
                .HasOne(p => p.DeliveryMachine)
                .WithMany(p => p.Packages)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Courier>()
                .HasOne(c => c.DeliveryMachine)
                .WithOne(c => c.Courier)
                .HasForeignKey<Courier>(c => c.DeliveryMachineId);

            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        }
    }
}