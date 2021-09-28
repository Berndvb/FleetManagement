using FleetManagement.Domain.Interfaces;
using FleetManagement.Domain.Models;
using FleetManagement.EFCore.Infrastructure;

namespace FleetManager.EFCore.Repositories
{
    public class ReparationRepository : GenericRepository<Repare>, IReparationRepository
    {
        public ReparationRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
