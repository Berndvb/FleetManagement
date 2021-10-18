using System.Collections.Generic;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using MediatR.Cqrs.Execution;

namespace FleetManagement.BLL.Features.Read.DriverManagement.GetAllDriverOverviews
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
