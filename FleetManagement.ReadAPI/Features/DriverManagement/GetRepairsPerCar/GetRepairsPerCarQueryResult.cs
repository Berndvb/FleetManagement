using FleetManagement.Framework.Models.Dtos;
using MediatR.Cqrs.Execution;
using System.Collections.Generic;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetReparationsPerCar
{
    public class GetRepairsPerCarQueryResult : ExecutionResult
    {
        public List<VehicleRepareDto> VehicleVehicleRepairs { get; }

        public GetRepairsPerCarQueryResult(List<VehicleRepareDto> vehicleVehicleRepairs)
        {
            VehicleVehicleRepairs = vehicleVehicleRepairs;
        }

        private GetRepairsPerCarQueryResult()
        {
        }
    }
}
