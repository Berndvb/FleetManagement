using FleetManagement.Domain.Interfaces;
using FleetManagement.Domain.Models;
using FleetManagement.EFCore.Infrastructure;

namespace FleetManager.EFCore.Repositories
{
    public class ChauffeurRepository : GenericRepository<ReadChauffeur>, IChauffeurRepository
    {
        public ChauffeurRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
