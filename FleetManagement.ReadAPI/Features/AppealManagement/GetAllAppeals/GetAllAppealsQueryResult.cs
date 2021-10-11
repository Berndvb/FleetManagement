using FleetManagement.Framework.Models.Dtos.ReadDtos;
using MediatR.Cqrs.Execution;
using System.Collections.Generic;

namespace FleetManagement.ReadAPI.Features.AppealManagement.GetAllAppeals
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
