using FleetManagement.Framework.Models.Dtos;
using MediatR.Cqrs.Execution;
using System.Collections.Generic;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetVehicleDetails
{
    public class GetVehicleDetailsQueryResult : ExecutionResult
    {
        public List<VehicleDetailsDto> VehicleDetails { get; }

        public GetVehicleDetailsQueryResult(List<VehicleDetailsDto> vehicleDetails)
        {
            VehicleDetails = vehicleDetails;
        }

        private GetVehicleDetailsQueryResult()
        {
        }
    }
}
