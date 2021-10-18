using AutoMapper;
using FleetManagement.Domain.Interfaces.Repositories;
using FleetManagement.Domain.Models;
using System.Threading;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManagement.BLL.Models.Dtos.WriteDtos;
using System.Threading.Tasks;
using MediatR.Cqrs.Execution;
using FleetManagement.BLL.Services.Models;

namespace FleetManagement.BLL.Services
{
    public class FuelCardDriverService : IFuelCardDriverService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGeneralService _generalService;

        public FuelCardDriverService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IGeneralService generalService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _generalService = generalService;
        }

        public async Task UpdateFuelCardDriver(CancellationToken cancellationToken, FuelCardDriverDto fuelCardDriverDto, int fuelCardDriverId)
        {
            var fuelCardDriver = _mapper.Map<FuelCardDriver>(fuelCardDriverDto);

            await _unitOfWork.FuelCardDrivers.Update(cancellationToken, fuelCardDriver, fuelCardDriverId);

            _unitOfWork.Complete();
        }

        public async Task AddFuelCardDriver(CancellationToken cancellationToken, AddFuelCardDriverDto fuelCardDriverDto)
        {
            var fuelCardDriver = _mapper.Map<FuelCardDriver>(fuelCardDriverDto);

            await _unitOfWork.FuelCardDrivers.Insert(cancellationToken, fuelCardDriver);

            _unitOfWork.Complete();
        }

        public async Task<ExecutionError> HasOtherActiveFuelCardDrivers(CancellationToken cancellationToken, int fuelCardId, int driverId)
        {
            //Checks to see if there is another FuelCardDriver (connection between driver and fuelcard) that is active and has our driver or fuelcard registered to it.
            var fuelCardDrivers  = await _unitOfWork.FuelCardDrivers.GetListBy(
                cancellationToken,
                filter: x => x.Driver.Id.Equals(driverId) || x.FuelCard.Id.Equals(fuelCardId) && x.Active); 

            return fuelCardDrivers.Count switch
            {
                > 0 => null,
                _ => _generalService.ProcessValidationError(InputValidationCodes.MoreThanOneActiveRelation)
            };
        }
    }
}
