using FleetManagement.BLL.Models.Dtos.ReadDtos;
using MediatR;
using MediatR.Cqrs.Execution;
using System;

namespace FleetManagement.BLL.Features.DriverZone.GetDriverDetails
{
    public class GetDriverDetailsQueryResult : ExecutionResult
    {
        public DriverDetailsDto DriverDetails { get; }

        public GetDriverDetailsQueryResult(DriverDetailsDto driverDetails)
        {
            DriverDetails = driverDetails;
        }

        private GetDriverDetailsQueryResult()
        {
        }
    }
}
