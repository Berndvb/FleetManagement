using FleetManagement.Framework.Models.Dtos.ShowDtos;
using MediatR.Cqrs.Execution;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetDriverDetails
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
