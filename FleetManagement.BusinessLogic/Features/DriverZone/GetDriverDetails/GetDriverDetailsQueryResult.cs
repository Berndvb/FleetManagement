using FleetManagement.BLL.Models.Dtos.ReadDtos;
using MediatR.Cqrs.Execution;

namespace FleetManagement.BLL.Features.DriverZone.GetDriverDetails
{
    public class GetDriverDetailsQueryResult : ExecutionResult
    {
        public ShowDriverDetailsDto DriverDetails { get; }

        public GetDriverDetailsQueryResult(ShowDriverDetailsDto driverDetails)
        {
            DriverDetails = driverDetails;
        }

        private GetDriverDetailsQueryResult()
        {
        }
    }
}
