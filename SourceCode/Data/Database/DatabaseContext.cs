using FleedManagement.Api.Data.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace FleedManagement.Api.Data.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<ReadTankkaart> Tankkaarten { get; set; }
        public DbSet<ReadChauffeur> Chauffeurs { get; set; }
        public DbSet<ReadVoertuig> Voertuigen { get; set; }
        public DbSet<ReadHerstelling> Herstellingen { get; set; }
        public DbSet<ReadOnderhoudsbeurt> Onderhoudsbeurten { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
    }
}
