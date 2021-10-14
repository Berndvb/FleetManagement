using System.Collections.Generic;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using MediatR.Cqrs.Execution;

namespace FleetManagement.BLL.Features.Read.AppealManagement.GetAllAppeals
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
