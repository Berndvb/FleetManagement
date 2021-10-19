using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManagement.BLL.Services;
using FleetManagement.BLL.Services.Models;
using FleetManagement.Framework.Constants;
using FleetManager.EFCore.UOW;
using MediatR.Cqrs.Execution;
using MediatR.Cqrs.Queries;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement.BLL.Features.DriverZone.GetDriverDetails
{
    public class GetDriverDetailsQueryHandler : QueryHandler<GetDriverDetailsQuery, GetDriverDetailsQueryResult>
    {
        private readonly IDriverService _driverService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGeneralService _generalService;

        public GetDriverDetailsQueryHandler(
            IDriverService driverService, 
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            IGeneralService generalService)
        {
            _driverService = driverService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _generalService = generalService;
        }

        public async override Task<GetDriverDetailsQueryResult> Handle(
            GetDriverDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var driverDetails = await GetDriverDetails(cancellationToken, request.DriverId);
            if (driverDetails != null)
            {
                var error = new ExecutionError("We couldn't find and retrieve any driver data.", Constants.ErrorCodes.DataNotFound);
                return BadRequest(error);
            }

            return new GetDriverDetailsQueryResult(driverDetails);
        }

        public async Task<DriverDetailsDto> GetDriverDetails(CancellationToken cancellationToken, int driverId)
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
    }
}
