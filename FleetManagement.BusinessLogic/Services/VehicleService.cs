using AutoMapper;
using FleetManagement.Domain.Interfaces;
using FleetManagement.Domain.Models;
using FleetManagement.Framework.Models.Dtos;

namespace FleetManagement.BLL.Services.DI
{
    public class VehicleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VehicleService(
            IUnitOfWork unitOfWork, 
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void UpdateVehicle(VehicleDto vehicleDto)
        {
            var vehicle = _mapper.Map<Vehicle>(vehicleDto);

            _unitOfWork.Vehicles.Update(vehicle);

            _unitOfWork.Complete();
        }

        public void UpdateVehicle(VehicleDetailsDto vehicleDetailsDto)
        {
            var vehicle = _mapper.Map<Vehicle>(vehicleDetailsDto);

            _unitOfWork.Vehicles
                .Update(vehicle,
                x => x.Id,
                x => x.Maintenances,
                x => x.Reparations,
                x => x.Drivers,
                x => x.Appeals);

            _unitOfWork.Complete();
        }
    }
}
