﻿using FleetManagement.Domain.Interfaces;
using FleetManagement.Domain.Models;
using FleetManagement.EFCore.Infrastructure;

namespace FleetManager.EFCore.Repositories
{
    public class VehicleRepository : GenericRepository<ReadVehicle>, IVehicleRepository
    {
        public VehicleRepository(DatabaseContext context) : base(context)
        {
        }
    }
}