using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Services;
using MediatR.Cqrs.Queries;

namespace FleetManagement.BLL.Features.Read.DriverManagement.GetDriverDetails
{
    public class GetDriverDetailsQueryHandler : QueryHandler<GetDriverDetailsQuery, GetDriverDetailsQueryResult>
    {
        private readonly IDriverService _driverService;

        public GetDriverDetailsQueryHandler(IDriverService driverService)
        {
            _driverService = driverService;
        }

        public async override Task<GetDriverDetailsQueryResult> Handle(
            GetDriverDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var idError = await _driverService.ValidateId(cancellationToken, request.DriverId);
            if (idError != null)
                return BadRequest(idError);

            var driverDetails = await _driverService.GetDriverDetails(cancellationToken, request.DriverId);

            return new GetDriverDetailsQueryResult(driverDetails);
        }
    }
}
