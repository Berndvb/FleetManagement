using FleetManagement.BLL.Services.Models;
using MediatR.Cqrs.Execution;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FleetManager.EFCore.UOW;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement.BLL.Services
{
    internal class DriverService : IDriverService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGeneralService _generalService;
        private readonly IMapper _mapper;

        public DriverService(
            IUnitOfWork unitOfWork,
            IGeneralService generalService,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _generalService = generalService;
            _mapper = mapper;
        }

   

        public async Task<ExecutionError> ValidateId(CancellationToken cancellationToken, int id)
        {
            var ids = await _unitOfWork.Drivers.GetIds(id, cancellationToken);

            var validationCode =  ids.Count switch
            {
                0 => InputValidationCodes.IdNotFound,
                > 1 => InputValidationCodes.IdNotUnique,
                _ => InputValidationCodes.OK,
            };

            if (validationCode != InputValidationCodes.OK)
                return _generalService.ProcessValidationError(validationCode, nameof(id));

            return null;
        }

        #region logic for service-pattern

        //logic to implement service-pattern for GetDriverDetails (as practice)
        public async Task<DriverDetailsDto> GetDriverDetails(int driverId, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.Drivers.GetBy(
                cancellationToken,
                filter: x => x.Id.Equals(driverId),
                including: x => x
                    .Include(y => y.Identity)
                    .Include(y => y.Contactinfo)
                    .ThenInclude(y => y.Address));

            var driverdetaillsDto = _mapper.Map<DriverDetailsDto>(driver);

            return driverdetaillsDto;
        }

        #endregion
    }
}
