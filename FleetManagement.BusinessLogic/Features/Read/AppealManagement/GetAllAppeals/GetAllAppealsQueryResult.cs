using System.Collections.Generic;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using MediatR.Cqrs.Execution;

namespace FleetManagement.BLL.Features.Read.AppealManagement.GetAllAppeals
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
