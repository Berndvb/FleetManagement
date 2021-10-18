﻿using System.Collections.Generic;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using MediatR.Cqrs.Execution;

namespace FleetManagement.BLL.Features.Read.DriverManagement.GetAllDriverOverviews
{
    public class GetDriverOverviewsQueryResult : ExecutionResult
    {
        public List<DriverOverviewDto> DriverOverviews { get; }

        public GetDriverOverviewsQueryResult(List<DriverOverviewDto> driverOverviews)
        {
            DriverOverviews = driverOverviews;
        }

        private GetDriverOverviewsQueryResult()
        {
        }
    }
}