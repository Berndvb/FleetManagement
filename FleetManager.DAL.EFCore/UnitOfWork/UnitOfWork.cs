using FleetManagement.Domain.Interfaces;
using FleetManagement.EFCore.Infrastructure;
using FleetManager.EFCore.Repositories;

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

        public IIdentityVehicleRepository IdentityVehicles { get; set; }

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
            Appeals = new AppealRepository(_context);
            Drivers = new DriverRepository(_context);
            Reparations = new ReparationRepository(_context);
            Maintenance = new MaintenanceRepository(_context);
            FuelCards = new FuelCardRepository(_context);
            Vehicles = new VehicleRepository(_context);
            DriverVehicles = new DriverVehicleRepository(_context);
            IdentityVehicles = new IdentityVehicleRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose() // when to dispose?
        {
            _context.Dispose();
        }
    }
}
