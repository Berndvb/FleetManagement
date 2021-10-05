using AutoMapper;
using FleetManagement.Domain.Interfaces.Repositories;
using FleetManagement.Domain.Models;
using FleetManagement.Framework.Models.Dtos;

namespace FleetManagement.BLL.Services
{
    public class VehicleService : IVehicleService
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

            _unitOfWork.Vehicles.Update(vehicle);

            _unitOfWork.Complete();
        }
    }
}
