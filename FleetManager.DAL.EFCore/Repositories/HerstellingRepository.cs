using FleetManagement.Domain.Interfaces;
using FleetManagement.Domain.Models;
using FleetManagement.EFCore.Infrastructure;

namespace FleetManager.EFCore.Repositories
{
    public class HerstellingRepository : GenericRepository<ReadHerstelling>, IHerstellingRepository
    {
        public HerstellingRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
