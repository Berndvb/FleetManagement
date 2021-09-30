using AutoMapper;
using FleetManagement.Domain.Interfaces;
using FleetManagement.Domain.Models;
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

        public async Task<List<VehicleDetailsDto>> GetVehicleDetailsForDriver(int driverId)
        {
            var driverVehicles = await _unitOfWork.DriverVehicles
                .Include(x => x.Vehicle)
                .Include(x => x.Vehicle.Identity)
                .Where(x => x.Driver.Id.Equals(driverId))
                .ToListAsync();

            var vehicleDetailsDtos = _mapper.Map<List<VehicleDetailsDto>>(driverVehicles);

            return vehicleDetailsDtos;
        }
    }
}
