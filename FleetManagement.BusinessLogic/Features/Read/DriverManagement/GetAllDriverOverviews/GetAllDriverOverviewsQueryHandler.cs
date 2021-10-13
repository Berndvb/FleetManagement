using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManagement.BLL.Services;
using FleetManagement.Domain.Infrastructure.Pagination;
using FleetManagement.Framework.Constants;
using MediatR.Cqrs.Execution;
using MediatR.Cqrs.Queries;

namespace FleetManagement.BLL.Features.Read.DriverManagement.GetAllDriverOverviews
{
    public class GetAllDriverOverviewsQueryHandler : QueryHandler<GetAllDriverOverviewsQuery, GetAllDriverOverviewsQueryResult>
    {
        private readonly IDriverService _driverService;

        public GetAllDriverOverviewsQueryHandler(IDriverService driverService)
        {
            _driverService = driverService;
        }

        public async override Task<GetAllDriverOverviewsQueryResult> Handle(
            GetAllDriverOverviewsQuery request,
            CancellationToken cancellationToken)
        {
            var driverOverviews = await _driverService.GetDriverOverviews(cancellationToken, onlyInService: request.OnlyInService, request.PagingParameters);
            if (driverOverviews.Count == 0)
            {
                var warning = new ExecutionWarning("We couldn't find and retrieve any driver-overview data.", Constants.WarningCodes.NoData);
                return SucceededWithNoData(warning);
            }

            var result = new GetAllDriverOverviewsQueryResult(driverOverviews);
            if (request.PagingParameters != null)
                result.FillPagingInfo((PaginatedList<DriverOverviewDto>)driverOverviews);

            return result;
        }
    }
}
