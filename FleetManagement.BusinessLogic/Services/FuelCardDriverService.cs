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

        public void UpdateFuelCardDriver(CancellationToken cancellationToken, FuelCardDriverDto fuelCardDriverDto)
        {
            var fuelCardDriver = _mapper.Map<FuelCardDriver>(fuelCardDriverDto);

            _unitOfWork.FuelCardDrivers.Update(cancellationToken, fuelCardDriver);

            _unitOfWork.Complete();
        }

        public void AddFuelCardDriver(CancellationToken cancellationToken, AddFuelCardDriverDto fuelCardDriverDto)
        {
            var fuelCardDriver = _mapper.Map<FuelCardDriver>(fuelCardDriverDto);

            _unitOfWork.FuelCardDrivers.Insert(cancellationToken, fuelCardDriver);

            _unitOfWork.Complete();
        }

        public async Task<ExecutionError> HasOtherActiveFuelCardDrivers(CancellationToken cancellationToken, int fuelCardId, int driverId)
        {
            var fuelCardDrivers  = await _unitOfWork.FuelCardDrivers.GetListBy(
                cancellationToken,
                filter: x => x.Driver.Id.Equals(driverId) && x.FuelCard.Id.Equals(fuelCardId));

            return fuelCardDrivers.Count switch
            {
                > 0 => null,
                _ => _generalService.ProcessValidationError(InputValidationCodes.MoreThanOneActiveRelation)
            };
        }
    }
}
