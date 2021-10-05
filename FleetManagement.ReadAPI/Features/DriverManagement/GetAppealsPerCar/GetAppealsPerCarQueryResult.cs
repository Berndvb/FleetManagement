using FleetManagement.Framework.Models.Dtos;
using MediatR.Cqrs.Execution;
using System.Collections.Generic;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetAppealsPerCar
{
    public class GetAppealsPerCarQueryResult : ExecutionResult
    {
        public List<VehicleAppealDto> VehicleAppeals { get; }

        public GetAppealsPerCarQueryResult(List<VehicleAppealDto> vehicleAppeals)
        {
            VehicleAppeals = vehicleAppeals;
        }

        private GetAppealsPerCarQueryResult()
        {
        }
    }
}
