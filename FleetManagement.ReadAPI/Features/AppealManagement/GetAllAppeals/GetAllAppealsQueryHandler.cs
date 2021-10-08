using FleetManagement.BLL.Services;
using FleetManagement.Framework.Constants;
using MediatR.Cqrs.Execution;
using MediatR.Cqrs.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Features.AppealManagement.GetAllAppeals
{
    public class GetAllAppealsQueryHandler : QueryHandler<GetAllAppealsQuery, GetAllAppealsQueryResult>
    {
        private readonly IAppealService _appealService;

        public GetAllAppealsQueryHandler(
            IAppealService appealService)
        {
            _appealService = appealService;
        }

        public async override Task<GetAllAppealsQueryResult> Handle(
            GetAllAppealsQuery request,
            CancellationToken cancellationToken)
        {
            var appeals = await _appealService.GetAllAppeals();
            if (appeals.Count == 0)
            {
                var dataError = new ExecutionError("We couldn't find and retrieve any fuelcard data.", Constants.ErrorCodes.DataNotFound);
                return NotFound(dataError);
            }

            return new GetAllAppealsQueryResult(appeals);
        }
    }
}
