using FleetManagement.Domain.Models;
using FleetManager.Domain.Interfaces;

namespace FleetManagement.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Appeal> Appeals { get; }

        IGenericRepository<Driver> Drivers { get; }

        IGenericRepository<Repare> Reparations { get; }

        IGenericRepository<Maintenance> Maintenance { get; }

        IGenericRepository<FuelCard> FuelCards { get; }

        IGenericRepository<Vehicle> Vehicles { get; }

        IGenericRepository<DriverVehicle> DriverVehicles { get; }

        IGenericRepository<IdentityVehicle> IdentityVehicles { get; }
        int Complete();
    }
}
