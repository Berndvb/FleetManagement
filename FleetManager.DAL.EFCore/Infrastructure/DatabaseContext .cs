using FleetManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement.EFCore.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DbSet<ReadFuelCard> Tankkaarten { get; set; }
        public DbSet<ReadDriver> Chauffeurs { get; set; }
        public DbSet<ReadAppeal> Aanvragen { get; set; }
        public DbSet<ReadVehicle> Voertuigen { get; set; }
        public DbSet<ReadRepare> Herstellingen { get; set; }
        public DbSet<ReadMaintenance> Onderhoudsbeurten { get; set; }
        public DbSet<ReadListVerzekeringsmaatschappijen> Verzekeringsmaatschappijen { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
    }
}
