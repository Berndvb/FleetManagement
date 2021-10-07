using FleetManagement.Domain.Interfaces.Repositories;
using FleetManagement.Domain.Models;
using FleetManagement.EFCore.Infrastructure;
using FleetManager.Domain.Interfaces.Repositories;

namespace FleetManager.EFCore.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        public IGenericRepository<Appeal> Appeals { get; private set; }

        public IGenericRepository<Driver> Drivers { get; private set; }

        public IGenericRepository<Repare> Repairs { get; private set; }

        public IGenericRepository<Maintenance> Maintenance { get; private set; }

        public IGenericRepository<FuelCard> FuelCards { get; private set; }

        public IGenericRepository<Vehicle> Vehicles { get; private set; }

        public IGenericRepository<DriverVehicle> DriverVehicles { get; private set; }

        public IGenericRepository<IdentityVehicle> IdentityVehicles { get; private set; }

        public IGenericRepository<FuelCardDriver> FuelCardDrivers { get; private set; }

        public IGenericRepository<IdentityPerson> IdentityPersons { get; private set; }

        public UnitOfWork(
            DatabaseContext context,
            IGenericRepository<Appeal> appeals,
            IGenericRepository<Driver> drivers,
            IGenericRepository<Repare> repairs,
            IGenericRepository<Maintenance> maintenance,
            IGenericRepository<FuelCard> fuelCards,
            IGenericRepository<Vehicle> vehicles,
            IGenericRepository<DriverVehicle> driverVehicles,
            IGenericRepository<IdentityVehicle> identityVehicles,
            IGenericRepository<FuelCardDriver> fuelCardDrivers,
            IGenericRepository<IdentityPerson> identityPersons)
        {
            _context = context;
            Appeals = appeals;
            Drivers = drivers;
            Repairs = repairs;
            Maintenance = maintenance;
            FuelCards = fuelCards;
            Vehicles = vehicles;
            DriverVehicles = driverVehicles;
            IdentityVehicles = identityVehicles;
            FuelCardDrivers = fuelCardDrivers;
            IdentityPersons = identityPersons;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        ~UnitOfWork() { _context.Dispose(); } //DESTUCTOR!
    }
}
