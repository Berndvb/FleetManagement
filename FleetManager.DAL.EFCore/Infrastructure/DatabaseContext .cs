using FleetManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement.EFCore.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DbSet<ReadFuelCard> FuelCards { get; set; }
        public DbSet<ReadDriver> Drivers { get; set; }
        public DbSet<ReadAppeal> Appeals { get; set; }
        public DbSet<ReadVehicle> Vehicles { get; set; }
        public DbSet<ReadRepare> Reparations { get; set; }
        public DbSet<ReadMaintenance> Maintenances { get; set; }
        public DbSet<ReadListInsuranceCompanies> InsuranceCompanies { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
    }
}
