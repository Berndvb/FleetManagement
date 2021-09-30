﻿using AutoMapper;
using FleetManagement.Domain.Interfaces;
using FleetManagement.Framework.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Services
{
    public class MaintenanceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MaintenanceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<VehicleMaintenanceDto>> GetMaintenancesForDriverPerCar(int driverId, int vehicleId)//for lazy loading @ GetVehicleDetailsForDriver
        {
            var maintenances = await _unitOfWork.Maintenance
                .GetAll()
                .Where(x => x.Driver.Id.Equals(driverId) && x.Vehicle.Id.Equals(vehicleId))
                .ToListAsync();

            var maintenanceDtos = _mapper.Map<List<VehicleMaintenanceDto>>(maintenances);


            return maintenanceDtos;
        }
    }
}