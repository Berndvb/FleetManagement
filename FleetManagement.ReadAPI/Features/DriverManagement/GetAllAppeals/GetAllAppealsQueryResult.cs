using FleetManagement.Framework.Models.Dtos.ShowDtos;
using MediatR.Cqrs.Execution;
using System.Collections.Generic;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetTotalAppeals
{
    public class GetAllAppealsQueryResult : ExecutionResult
    {
        public List<AppealDto> Appeals { get; }

        public GetAllAppealsQueryResult(List<AppealDto> appeals)
        {
            Appeals = appeals;
        }

        private GetAllAppealsQueryResult()
        {
        }
    }
}
