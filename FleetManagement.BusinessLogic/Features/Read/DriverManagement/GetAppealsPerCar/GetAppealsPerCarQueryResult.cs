using System.Collections.Generic;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using MediatR.Cqrs.Execution;

namespace FleetManagement.BLL.Features.Read.DriverManagement.GetAppealsPerCar
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
