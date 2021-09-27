using FleetManagement.Domain.Interfaces;
using FleetManagement.Domain.Models;
using FleetManagement.EFCore.Infrastructure;

namespace FleetManager.EFCore.Repositories
{
    public class MaintenanceRepository : GenericRepository<ReadMaintenance>, IMaintenanceRepository
    {
        public MaintenanceRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
