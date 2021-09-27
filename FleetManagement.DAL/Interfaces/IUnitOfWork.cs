using System;

namespace FleetManagement.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAppealRepository Appeals { get; }
        IDriverRepository Drivers { get; }
        IReparationRepository Reparations { get; }
        IMaintenanceRepository Maintenance { get; }
        IFuelCardRepository FuelCards { get; }
        IVehicleRepository Vehicles { get; }
        IDriverVehicleRepository DriverVehicles { get; }
        IIdentityVehicleRepository IdentityVehicles { get; }
        int Complete();
    }
}
