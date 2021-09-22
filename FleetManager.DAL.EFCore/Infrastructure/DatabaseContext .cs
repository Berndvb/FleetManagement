using FleetManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement.EFCore.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DbSet<ReadTankaart> Tankkaarten { get; set; }
        public DbSet<ReadChauffeur> Chauffeurs { get; set; }
        public DbSet<ReadAanvraag> Aanvragen { get; set; }
        public DbSet<ReadVoertuig> Voertuigen { get; set; }
        public DbSet<ReadHerstelling> Herstellingen { get; set; }
        public DbSet<ReadOnderhoudsbeurt> Onderhoudsbeurten { get; set; }
        public DbSet<ReadListVerzekeringsmaatschappijen> Verzekeringsmaatschappijen { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
    }
}
