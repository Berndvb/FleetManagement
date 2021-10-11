using FleetManagement.BLL.Services;
using FleetManagement.Framework.Constants;
using FleetManagement.Framework.Helpers;
using FluentValidation;
using MediatR.Cqrs.Execution;
using MediatR.Cqrs.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Features.AppealManagement.GetAllAppeals
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
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                var validationError = _generalService.ProcessValidationError(validationResult);
                return BadRequest(validationError);
            }

            var appeals = await _appealService.GetAllAppeals(request.PagingParameters, request.AppealStatus.StringToAppealStatus());
            if (appeals.Count == 0)
            {
                var dataError = new ExecutionError("We couldn't find and retrieve any appeal data.", Constants.ErrorCodes.DataNotFound);
                return NotFound(dataError);
            }

            return new GetAllAppealsQueryResult(appeals);
        }
    }
}
