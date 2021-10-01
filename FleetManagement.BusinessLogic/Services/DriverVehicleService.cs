using AutoMapper;
using FleetManagement.Domain.Interfaces;
using FleetManagement.Domain.Models;
using FleetManagement.Framework.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Services
{
    public class DriverVehicleService
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

        public async Task<List<VehicleDetailsDto>> GetVehicleDetailsForDriver(int driverId)
        {
            var driverVehicles = await _unitOfWork.DriverVehicles.GetListBy(
                filter: x => x.Driver.Id.Equals(driverId),
                x => x.Include(y => y.Vehicle),
                x => x.Include(y => y.Vehicle.Identity));

            var vehicleDetailsDtos = _mapper.Map<List<VehicleDetailsDto>>(driverVehicles);

            return vehicleDetailsDtos;
        }

        public void UpdateDriverVehicle(DriverVehicleDto driverVehicleDto)
        {
            var driverVehicle = _mapper.Map<DriverVehicle>(driverVehicleDto);

            _unitOfWork.DriverVehicles.Update(driverVehicle,
                x => x.Driver,
                x => x.Vehicle);

            _unitOfWork.Complete();
        }
    }
}
