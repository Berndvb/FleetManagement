using FleetManagement.Framework.Models.Dtos.ShowDtos;
using MediatR.Cqrs.Execution;
using System.Collections.Generic;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetActiveDriverOverviews
{
    public class GetActiveDriverOverviewsQueryResult : ExecutionResult
    {
        public List<DriverOverviewDto> DriverOverviews { get; }

        public GetActiveDriverOverviewsQueryResult(List<DriverOverviewDto> driverOverviews)
        {
            DriverOverviews = driverOverviews;
        }

        private GetActiveDriverOverviewsQueryResult()
        {
        }
    }
}
