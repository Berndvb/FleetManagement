using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManagement.BLL.Services;
using FleetManagement.Domain.Interfaces.Repositories;
using MediatR.Cqrs.Queries;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement.BLL.Features.Read.DriverManagement.GetDriverDetails
{
    public class GetDriverDetailsQueryHandler : QueryHandler<GetDriverDetailsQuery, GetDriverDetailsQueryResult>
    {
        private readonly IDriverService _driverService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDriverDetailsQueryHandler(
            IDriverService driverService, 
            IUnitOfWork unitOfWork, 
            IMapper mapper)
        {
            _driverService = driverService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async override Task<GetDriverDetailsQueryResult> Handle(
            GetDriverDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var idError = await _driverService.ValidateId(cancellationToken, request.DriverId);
            if (idError != null)
                return BadRequest(idError);

            var driverDetails = await GetDriverDetails(cancellationToken, request.DriverId);

            return new GetDriverDetailsQueryResult(driverDetails);
        }

        public async Task<ShowDriverDetailsDto> GetDriverDetails(CancellationToken cancellationToken, int driverId)
        {
            var driver = await _unitOfWork.Drivers.GetBy(
                cancellationToken,
                filter: x => x.Id.Equals(driverId),
                including: x => x
                    .Include(y => y.Identity)
                    .Include(y => y.Contactinfo)
                        .ThenInclude(y => y.Address));

            var driverdetaillsDto = _mapper.Map<ShowDriverDetailsDto>(driver);

            return driverdetaillsDto;
        }
    }
}
