using AutoMapper;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManagement.BLL.Services.Models;
using FleetManager.EFCore.UOW;
using MediatR.Cqrs.Execution;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

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

   

        public async Task<ExecutionError> ValidateDriverId(int driverId, CancellationToken cancellationToken)
        {
            var ids = await _unitOfWork.Drivers.GetIds(driverId, cancellationToken);

            var validationCode =  ids.Count switch
            {
                0 => InputValidationCodes.IdNotFound,
                > 1 => InputValidationCodes.IdNotUnique,
                _ => InputValidationCodes.OK,
            };

            if (validationCode != InputValidationCodes.OK)
                return _generalService.ProcessValidationError(validationCode, nameof(driverId));

            return null;
        }

        #region logic for service-pattern

        //logic to implement service-pattern for GetDriverDetails (as practice)
        public async Task<IActionResult> GetValidDriverDetails(int driverId, CancellationToken cancellationToken)
        {
            var idValidationError = _generalService.ValidateId(driverId);
            if (idValidationError != null)
                return idValidationError;

            var driver = await _unitOfWork.Drivers.GetBy(
                cancellationToken,
                filter: x => x.Id.Equals(driverId),
                including: x => x
                    .Include(y => y.Identity)
                    .Include(y => y.Contactinfo)
                        .ThenInclude(y => y.Address));

            var entityValidationError = _generalService.ValidateEntity(driver);
            if (entityValidationError != null)
                return entityValidationError;

            var driverdetailsDto = _mapper.Map<DriverDetailsDto>(driver);

            return new OkObjectResult(driverdetailsDto);
        }

        #endregion
    }
}
