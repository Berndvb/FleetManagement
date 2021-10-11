using FleetManagement.Framework.Models.Dtos.ReadDtos;
using MediatR.Cqrs.Execution;
using System.Collections.Generic;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetAppealsPerCar
{
    public class GetAppealsPerCarQueryResult : ExecutionResult
    {
        public List<AppealDto> Appeals { get; }

        public GetAppealsPerCarQueryResult(List<AppealDto> appeals)
        {
            Appeals = appeals;
        }

        private GetAppealsPerCarQueryResult()
        {
        }
    }
}
