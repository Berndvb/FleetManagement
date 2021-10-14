using System.Collections.Generic;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using MediatR.Cqrs.Execution;

namespace FleetManagement.BLL.Features.Read.VehicleManagement.GetAllVehicles
{
    public class GetVehiclesQueryResult : ExecutionResult
    {
        public List<VehicleDetailsDto> Vehicles { get; set; }

        public GetVehiclesQueryResult(List<VehicleDetailsDto> vehicles)
        {
            Vehicles = vehicles;
        }

        private GetVehiclesQueryResult()
        {
        }
    }
}
