﻿using FleetManagement.Domain.Models;
using FleetManager.EFCore.Repositories;

namespace FleetManager.EFCore.UOW
{
    public interface IUnitOfWork
    {
        IGenericRepository<Appeal> Appeals { get; }

        IGenericRepository<Driver> Drivers { get; }

        IGenericRepository<Repare> Repairs { get; }

        IGenericRepository<Maintenance> Maintenance { get; }

        IGenericRepository<FuelCard> FuelCards { get; }

        IGenericRepository<Vehicle> Vehicles { get; }

        IGenericRepository<DriverVehicle> DriverVehicles { get; }

        IGenericRepository<IdentityVehicle> IdentityVehicles { get; }

        IGenericRepository<FuelCardDriver> FuelCardDrivers { get; }

        IGenericRepository<IdentityPerson> IdentityPersons { get; }
        int Complete();
    }
}