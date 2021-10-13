using System.Collections.Generic;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using MediatR.Cqrs.Execution;

namespace FleetManagement.BLL.Features.Read.DriverManagement.GetRepairsPerCar
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
