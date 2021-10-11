using FleetManagement.Framework.Models.Dtos.ReadDtos;
using MediatR.Cqrs.Execution;
using System.Collections.Generic;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetAllDriverOverviews
{
    public class GetAllDriverOverviewsQueryResult : ExecutionResult
    {
        public List<DriverOverviewDto> DriverOverviews { get; }

        public GetAllDriverOverviewsQueryResult(List<DriverOverviewDto> driverOverviews)
        {
            DriverOverviews = driverOverviews;
        }

        private GetAllDriverOverviewsQueryResult()
        {
        }
    }
}
