using FleetManagement.BLL.Services;
using FleetManagement.Framework;
using MediatR.Cqs.Execution;
using MediatR.Cqs.Queries;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Features.Driver.GetAllDriverOverviews
{
    public class GetAllDriverOverviewsQueryHandler : QueryHandler<GetAllDriverOverviewsQuery, GetAllDriverOverviewsQueryResult>
    {
        private readonly IDriverService _driverService;

        public GetAllDriverOverviewsQueryHandler(
            IDriverService driverService)
        {
            _driverService = driverService;
        }

        public async override Task<GetAllDriverOverviewsQueryResult> Handle(
            GetAllDriverOverviewsQuery request,
            CancellationToken cancellationToken)
        {
            var driverOverviews = await _driverService.GetAllDriverOverviews(request.InService);

            return new GetAllDriverOverviewsQueryResult(driverOverviews);
        }
    }
}
