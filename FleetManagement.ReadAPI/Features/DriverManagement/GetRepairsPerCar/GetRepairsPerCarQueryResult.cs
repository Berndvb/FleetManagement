using FleetManagement.Framework.Models.Dtos;
using FleetManagement.Framework.Models.Dtos.ReadDtos;
using MediatR.Cqrs.Execution;
using System.Collections.Generic;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetReparationsPerCar
{
    public class GetRepairsPerCarQueryResult : ExecutionResult
    {
        public List<RepareDto> VehicleVehicleRepairs { get; }

        public GetRepairsPerCarQueryResult(List<RepareDto> vehicleVehicleRepairs)
        {
            VehicleVehicleRepairs = vehicleVehicleRepairs;
        }

        private GetRepairsPerCarQueryResult()
        {
        }
    }
}
