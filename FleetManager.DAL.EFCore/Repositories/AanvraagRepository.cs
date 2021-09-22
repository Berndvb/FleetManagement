using FleetManagement.Domain.Interfaces;
using FleetManagement.Domain.Models;
using FleetManagement.EFCore.Infrastructure;

namespace FleetManager.EFCore.Repositories
{
    public class AanvraagRepository : GenericRepository<ReadAanvraag>, IAanvraagRepository
    {
        public AanvraagRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
