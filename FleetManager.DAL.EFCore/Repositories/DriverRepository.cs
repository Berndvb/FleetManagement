using FleetManagement.Domain.Interfaces;
using FleetManagement.Domain.Models;
using FleetManagement.EFCore.Infrastructure;

namespace FleetManager.EFCore.Repositories
{
    public class DriverRepository : GenericRepository<ReadDriver>, IDriverRepository
    {
        public DriverRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
