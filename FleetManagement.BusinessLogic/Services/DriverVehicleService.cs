﻿using AutoMapper;
using FleetManagement.Domain.Interfaces.Repositories;
using FleetManagement.Domain.Models;
using FleetManagement.Framework.Models.Dtos;

namespace FleetManagement.BLL.Services
{
    public class DriverVehicleService : IDriverVehicleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DriverVehicleService(
            IUnitOfWork unitOfWork, 
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void UpdateDriverVehicle(DriverVehicleDto driverVehicleDto)
        {
            var driverVehicle = _mapper.Map<DriverVehicle>(driverVehicleDto);

            _unitOfWork.DriverVehicles.Update(driverVehicle);

            _unitOfWork.Complete();
        }
    }
}
