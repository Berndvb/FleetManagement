using AutoMapper;
using FleetManagement.Domain.Interfaces;
using FleetManagement.Framework.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Services
{
    public class DriverVehicleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DriverVehicleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VehicleDetailsDto>> GetVehicleDetailsForDriver(int driverId)
        {
            var vehicles = await _unitOfWork.DriverVehicles
                .Include(x => x.Vehicle)
                .Include(x => x.Vehicle.Identity)
                .Where(x => x.Driver.Id.Equals(driverId))
                .ToListAsync();

            var vehicleDetailsDtos = new List<VehicleDetailsDto>();
            foreach (var vehicle in vehicles)
            {
                var vehicleIdentityDto = _mapper.Map<IdentityVehicleDto>(vehicle);
                var driverVehicleDto = _mapper.Map<DriverVehicleDto>(vehicle);
                var vehicleDetailsDto = new VehicleDetailsDto(vehicleIdentityDto, driverVehicleDto, vehicle.Vehicle.Mileage);
                vehicleDetailsDtos.Add(vehicleDetailsDto);
            }

            return vehicleDetailsDtos;
        }
    }
}
