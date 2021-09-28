using FleetManagement.Domain.Interfaces;
using FleetManagement.Domain.Models;
using FleetManagement.EFCore.Infrastructure;

namespace FleetManager.EFCore.Repositories
{
    public class FuelCardRepository : GenericRepository<FuelCard>, IFuelCardRepository
    {
        public FuelCardRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
