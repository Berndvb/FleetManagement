using System.Collections.Generic;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using MediatR.Cqrs.Execution;

namespace FleetManagement.BLL.Features.DriverZone.GetAppealsForDriver
{
    public class GetAppealsForDriverQueryResult : ExecutionResult
    {
        public List<AppealDto> Appeals { get; }

        public GetAppealsForDriverQueryResult(List<AppealDto> appeals)
        {
            Appeals = appeals;
        }

        private GetAppealsForDriverQueryResult()
        {
        }
    }
}
