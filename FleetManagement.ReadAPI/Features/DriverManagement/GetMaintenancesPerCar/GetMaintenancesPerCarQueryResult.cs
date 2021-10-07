using FleetManagement.Framework.Models.Dtos;
using MediatR.Cqrs.Execution;
using System.Collections.Generic;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetMaintenancesPerCar
{
    public class GetMaintenancesPerCarQueryResult : ExecutionResult
    {
        public List<MaintenanceDto> VehicleMaintenances { get; }

        public GetMaintenancesPerCarQueryResult(List<MaintenanceDto> vehicleMaintenances)
        {
            VehicleMaintenances = vehicleMaintenances;
        }

        private GetMaintenancesPerCarQueryResult()
        {
        }
    }
}
