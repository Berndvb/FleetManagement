using FleetManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FleetManager.EFCore.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DbSet<FuelCard> FuelCards { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Appeal> Appeals { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Repare> Reparations { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<ListInsuranceCompanies> InsuranceCompanies { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appeal>()
                .HasOne(a => a.Repare)
                .WithOne(b => b.Appeal)
                .HasForeignKey<Appeal>(b => b.RepareId);

            modelBuilder.Entity<Appeal>()
                .HasOne(a => a.Maintenance)
                .WithOne(b => b.Appeal)
                .HasForeignKey<Appeal>(b => b.MaintenanceId);
        }
    }
}
