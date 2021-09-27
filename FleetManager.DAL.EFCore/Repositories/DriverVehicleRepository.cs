using FleetManagement.Domain.Interfaces;
using FleetManagement.Domain.Models;
using FleetManagement.EFCore.Infrastructure;

namespace FleetManager.EFCore.Repositories
{
    public class DriverVehicleRepository : GenericRepository<DriverVehicle>, IDriverVehicleRepository
    {
        public DriverVehicleRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
