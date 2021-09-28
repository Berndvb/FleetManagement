using FleetManagement.Domain.Interfaces;
using FleetManagement.Domain.Models;
using FleetManagement.EFCore.Infrastructure;

namespace FleetManager.EFCore.Repositories
{
    public class AppealRepository : GenericRepository<Appeal>, IAppealRepository
    {
        public AppealRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
