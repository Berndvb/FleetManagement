using FleetManagement.Domain.Interfaces;
using FleetManagement.Domain.Models;
using FleetManagement.EFCore.Infrastructure;

namespace FleetManager.EFCore.Repositories
{
    public class VoertuigRepository : GenericRepository<ReadVoertuig>, IVoertuigRepository
    {
        public VoertuigRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
