using FleetManagement.Framework.Models.Dtos.ShowDtos;
using MediatR.Cqrs.Execution;
using System.Collections.Generic;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetTotalAppeals
{
    public class GetAppealsQueryResult : ExecutionResult
    {
        public List<AppealDto> Appeals { get; }

        public GetAppealsQueryResult(List<AppealDto> appeals)
        {
            Appeals = appeals;
        }

        private GetAppealsQueryResult()
        {
        }
    }
}
