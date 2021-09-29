using AutoMapper;
using FleetManagement.Domain.Interfaces;
using FleetManagement.Framework.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Services
{
    public class RepareService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RepareService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<VehicleRepareDto>> GetReparationsForDriverPerCar(int driverId, int vehicleId)//for lazy loading @ GetVehicleDetailsForDriver
        {
            var reparations = await _unitOfWork.Repares
                .GetAll()
                .Where(x => x.Driver.Id.Equals(driverId) && x.Vehicle.Id.Equals(vehicleId))
                .ToListAsync();

            var reparationDtos = new List<VehicleRepareDto>();
            foreach (var reparation in reparations)
            {
                var reparationDto = _mapper.Map<VehicleRepareDto>(reparation);
                reparationDtos.Add(reparationDto);
            }

            return reparationDtos;
        }
    }
}
