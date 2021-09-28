using FleetManagement.Domain.Interfaces;
using FleetManagement.EFCore.Infrastructure;

namespace FleetManager.EFCore.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        public IAppealRepository Appeals { get; private set; }

        public IDriverRepository Drivers { get; private set; }

        public IReparationRepository Reparations { get; private set; }

        public IMaintenanceRepository Maintenance { get; private set; }

        public IFuelCardRepository FuelCards { get; private set; }

        public IVehicleRepository Vehicles { get; private set; }

        public IDriverVehicleRepository DriverVehicles { get; private set; }

        public IIdentityVehicleRepository IdentityVehicles { get; private set; }

        public UnitOfWork(
            DatabaseContext context,
            IAppealRepository appeals,
            IDriverRepository drivers,
            IReparationRepository reparations,
            IMaintenanceRepository maintenance,
            IFuelCardRepository fuelCards,
            IVehicleRepository vehicles,
            IDriverVehicleRepository driverVehicles,
            IIdentityVehicleRepository identityVehicles)
        {
            _context = context;
            Appeals = appeals;
            Drivers = drivers;
            Reparations = reparations;
            Maintenance = maintenance;
            FuelCards = fuelCards;
            Vehicles = vehicles;
            DriverVehicles = driverVehicles;
            IdentityVehicles = identityVehicles;
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
