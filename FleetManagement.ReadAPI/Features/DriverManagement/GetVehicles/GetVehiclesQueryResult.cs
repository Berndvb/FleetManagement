using FleetManagement.Framework.Models.Dtos;
using MediatR.Cqrs.Execution;
using System.Collections.Generic;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetVehicleDetails
{
    public class GetVehiclesQueryResult : ExecutionResult
    {
        public List<VehicleDetailsDto> VehicleDetails { get; }

        public GetVehiclesQueryResult(List<VehicleDetailsDto> vehicleDetails)
        {
            VehicleDetails = vehicleDetails;
        }

        private GetVehiclesQueryResult()
        {
        }
    }
}
