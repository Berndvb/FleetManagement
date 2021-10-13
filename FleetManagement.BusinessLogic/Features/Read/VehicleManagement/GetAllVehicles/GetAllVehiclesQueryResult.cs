using System.Collections.Generic;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using MediatR.Cqrs.Execution;

namespace FleetManagement.BLL.Features.Read.VehicleManagement.GetAllVehicles
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
