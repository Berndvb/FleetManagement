using FleetManagement.Framework.Models.Dtos;
using MediatR.Cqrs.Execution;
using System.Collections.Generic;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetVehicleDetails
{
    public class GetVehicleInfoQueryResult : ExecutionResult
    {
        public List<VehicleDetailsDto> VehicleDetails { get; }

        public GetVehicleInfoQueryResult(List<VehicleDetailsDto> vehicleDetails)
        {
            VehicleDetails = vehicleDetails;
        }

        private GetVehicleInfoQueryResult()
        {
        }
    }
}
