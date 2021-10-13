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

        //protected override void OnModelCreating(DBModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Repare>().Map(m =>
        //    {
        //        m.MapInheritedProperties();
        //        m.ToTable("Reparations");
        //    });

        //    modelBuilder.Entity<Maintenance>().Map(m =>
        //    {
        //        m.MapInheritedProperties();
        //        m.ToTable("CreditCards");
        //    });
        //}
    }
}
