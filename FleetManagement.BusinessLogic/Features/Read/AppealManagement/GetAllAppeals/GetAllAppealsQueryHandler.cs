using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManagement.BLL.Services;
using FleetManagement.Domain.Infrastructure.Pagination;
using FleetManagement.Framework.Constants;
using FleetManagement.Framework.Helpers;
using FluentValidation;
using MediatR.Cqrs.Execution;
using MediatR.Cqrs.Queries;

namespace FleetManagement.BLL.Features.Read.AppealManagement.GetAllAppeals
{
    public class GetAllAppealsQueryHandler : QueryHandler<GetAllAppealsQuery, GetAllAppealsQueryResult>
    {
        private readonly IAppealService _appealService;
        private readonly IGeneralService _generalService;
        private readonly IValidator<GetAllAppealsQuery> _validator;

        public GetAllAppealsQueryHandler(
            IAppealService appealService,
            IValidator<GetAllAppealsQuery> validator,
            IGeneralService generalService)
        {
            _appealService = appealService;
            _validator = validator;
            _generalService = generalService;
        }

        public async override Task<GetAllAppealsQueryResult> Handle(
            GetAllAppealsQuery request,
            CancellationToken cancellationToken)
        {
            var appeals = await _appealService.GetAllAppeals(cancellationToken, request.PagingParameters, request.AppealStatus.StringToAppealStatus());
            if (appeals.Count == 0)
            {
                var warning = new ExecutionWarning("We couldn't find and retrieve any appeal data.", Constants.WarningCodes.NoData);
                return SucceededWithNoData(warning);
            }

            var result = new GetAllAppealsQueryResult(appeals);

            if (request.PagingParameters != null)
                result.FillPagingInfo((PaginatedList<AppealDto>)appeals);

            return result;
        }
    }
}
