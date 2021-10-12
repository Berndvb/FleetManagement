using AutoMapper;
using FleetManagement.Domain.Interfaces.Repositories;
using FleetManagement.Domain.Models;
using FleetManagement.Framework.Models.Dtos.ReadDtos;
using FleetManagement.Framework.Models.Dtos.WriteDtos;
using System.Threading;

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

        public void UpdateDriverVehicle(CancellationToken cancellationToken, DriverVehicleDto driverVehicleDto)
        {
            var driverVehicle = _mapper.Map<DriverVehicle>(driverVehicleDto);

            _unitOfWork.DriverVehicles.Update(cancellationToken, driverVehicle);

            _unitOfWork.Complete();
        }

        public void AddDriverVehicle(CancellationToken cancellationToken, AddDriverVehicleDto driverVehicleDto)
        {
            var driverVehicle = _mapper.Map<DriverVehicle>(driverVehicleDto);

            _unitOfWork.DriverVehicles.Insert(cancellationToken, driverVehicle);

            _unitOfWork.Complete();
        }
    }
}
