using System.Collections.Generic;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using MediatR.Cqrs.Execution;

namespace FleetManagement.BLL.Features.Read.DriverManagement.GetMaintenancesPerCar
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
