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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDriverDetailsQueryHandler(
            IUnitOfWork unitOfWork, 
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async override Task<GetDriverDetailsQueryResult> Handle(
            GetDriverDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var driverDetails = await GetDriverDetails(request.DriverId, cancellationToken);
            if (driverDetails == null)
            {
                var error = new ExecutionError("We couldn't find and retrieve any driver data.", Constants.ErrorCodes.DataNotFound);
                return BadRequest(error);
            }

            return new GetDriverDetailsQueryResult(driverDetails);
        }

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
    }
}
