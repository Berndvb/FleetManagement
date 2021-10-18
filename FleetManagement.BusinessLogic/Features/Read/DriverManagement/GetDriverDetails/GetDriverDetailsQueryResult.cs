using FleetManagement.BLL.Models.Dtos.ReadDtos;
using MediatR.Cqrs.Execution;

namespace FleetManagement.BLL.Features.Read.DriverManagement.GetDriverDetails
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
