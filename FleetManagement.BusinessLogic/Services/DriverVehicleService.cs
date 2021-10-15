using AutoMapper;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManagement.BLL.Models.Dtos.WriteDtos;
using FleetManagement.BLL.Services.Models;
using FleetManagement.Domain.Interfaces.Repositories;
using FleetManagement.Domain.Models;
using MediatR.Cqrs.Execution;
using System.Threading;
using System.Threading.Tasks;

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

        public async Task UpdateDriverVehicle(CancellationToken cancellationToken, DriverVehicleDto driverVehicleDto, int driverVehicleId)
        {
            var driverVehicle = _mapper.Map<DriverVehicle>(driverVehicleDto);

            await _unitOfWork.DriverVehicles.Update(cancellationToken, driverVehicle, driverVehicleId);

            _unitOfWork.Complete();
        }

        public async Task AddDriverVehicle(CancellationToken cancellationToken, AddDriverVehicleDto driverVehicleDto)
        {
            var driverVehicle = _mapper.Map<DriverVehicle>(driverVehicleDto);

            await _unitOfWork.DriverVehicles.Insert(cancellationToken, driverVehicle);

            _unitOfWork.Complete();
        }

        public async Task<ExecutionError> HasOtherActiveDriverVehicles(CancellationToken cancellationToken, int vehicleId, int driverId)
        {
            var driverVehicles = await _unitOfWork.DriverVehicles.GetListBy(
                cancellationToken,
                filter: x => x.Driver.Id.Equals(driverId) || x.Vehicle.Id.Equals(vehicleId) && x.Active);

            return driverVehicles.Count switch
            {
                > 0 => null,
                _ => _generalService.ProcessValidationError(InputValidationCodes.MoreThanOneActiveRelation)
            };
        }
    }
}
