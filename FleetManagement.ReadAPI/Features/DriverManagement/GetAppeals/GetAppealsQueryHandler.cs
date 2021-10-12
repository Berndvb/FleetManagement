using FleetManagement.BLL.Services;
using FleetManagement.Domain.Infrastructure.Pagination;
using FleetManagement.Framework.Constants;
using FleetManagement.Framework.Models.Dtos.ReadDtos;
using MediatR.Cqrs.Execution;
using MediatR.Cqrs.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetTotalAppeals
{
    public class GetAppealsQueryHandler : QueryHandler<GetAppealsQuery, GetAppealsQueryResult>
    {
        private readonly IDriverService _driverService;

        public GetAppealsQueryHandler(IDriverService driverService)
        {
            _driverService = driverService;
        }

        public async override Task<GetAppealsQueryResult> Handle(
            GetAppealsQuery request,
            CancellationToken cancellationToken)
        {
            var idError = await _driverService.CheckforIdError(cancellationToken, request.DriverId);
            if (idError != null)
                return BadRequest(idError);

            var driverAppeals = await _driverService.GetAppealsForDriver(cancellationToken, request.DriverId, request.PagingParameters);
            if (driverAppeals.Count == 0)
            {
                var warning = new ExecutionWarning("We couldn't find and retrieve any driver-appeal data.", Constants.WarningCodes.NoData);
                return SucceededWithNoData(warning);
            }

            var result = new GetAppealsQueryResult(driverAppeals);
            if (request.PagingParameters != null)
                result.FillPagingInfo((PaginatedList<AppealDto>)driverAppeals);

            return result;
        }
    }
}
