using FleetManagement.Domain.Interfaces;
using FleetManagement.Domain.Models;
using FleetManagement.EFCore.Infrastructure;

namespace FleetManager.EFCore.Repositories
{
    public class TankkaartRepository : GenericRepository<ReadTankkaart>, ITankkaartRepository
    {
        public TankkaartRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
