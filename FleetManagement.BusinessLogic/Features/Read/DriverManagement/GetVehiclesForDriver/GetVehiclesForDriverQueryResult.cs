using System.Collections.Generic;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using MediatR.Cqrs.Execution;

namespace FleetManagement.BLL.Features.Read.DriverManagement.GetVehicleInfo
{
    public class GetVehiclesForDriverQueryResult : ExecutionResult
    {
        public List<VehicleDetailsDto> VehicleDetails { get; }

        public GetVehiclesForDriverQueryResult(List<VehicleDetailsDto> vehicleDetails)
        {
            VehicleDetails = vehicleDetails;
        }

        private GetVehiclesForDriverQueryResult()
        {
        }
    }
}
