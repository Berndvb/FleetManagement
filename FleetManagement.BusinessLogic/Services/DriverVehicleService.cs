using AutoMapper;
using FleetManagement.Domain.Interfaces.Repositories;
using FleetManagement.Domain.Models;
using System.Threading;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManagement.BLL.Models.Dtos.WriteDtos;
using MediatR.Cqrs.Execution;
using System.Threading.Tasks;
using FleetManagement.BLL.Services.Models;

namespace FleetManagement.BLL.Services
{
    public class DriverVehicleService : IDriverVehicleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGeneralService _generalService;

        public DriverVehicleService(
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            IGeneralService generalService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _generalService = generalService;
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

        public async Task<ExecutionError> HasOtherActiveDriverVehicles(CancellationToken cancellationToken, int vehicleId, int driverId)
        {
            var driverVehicles = await _unitOfWork.DriverVehicles.GetListBy(
                cancellationToken,
                filter: x => x.Driver.Id.Equals(driverId) && x.Vehicle.Id.Equals(vehicleId));

            return driverVehicles.Count switch
            {
                > 0 => null,
                _ => _generalService.ProcessValidationError(InputValidationCodes.MoreThanOneActiveRelation)
            };
        }
    }
}
