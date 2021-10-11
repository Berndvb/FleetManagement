using FleetManagement.Framework.Models.Dtos;
using FleetManagement.Framework.Models.Dtos.ReadDtos;
using MediatR.Cqrs.Execution;
using System.Collections.Generic;

namespace FleetManagement.ReadAPI.Features.VehicleManagement.GetAllVehicles
{
    public class GetAllVehiclesQueryResult : ExecutionResult
    {
        public List<VehicleDetailsDto> Vehicles { get; set; }

        public GetAllVehiclesQueryResult(List<VehicleDetailsDto> vehicles)
        {
            Vehicles = vehicles;
        }

        private GetAllVehiclesQueryResult()
        {
        }
    }
}
