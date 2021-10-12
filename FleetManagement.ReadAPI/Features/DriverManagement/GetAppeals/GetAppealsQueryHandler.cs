using FleetManagement.BLL.Services;
using FleetManagement.Domain.Infrastructure.Pagination;
using FleetManagement.Framework.Constants;
using FleetManagement.Framework.Models.Dtos.ReadDtos;
using FluentValidation;
using MediatR.Cqrs.Execution;
using MediatR.Cqrs.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetTotalAppeals
{
    public class GetAppealsQueryHandler : QueryHandler<GetAppealsQuery, GetAppealsQueryResult>
    {
        private readonly IDriverService _driverService;
        private readonly IGeneralService _generalService;
        private readonly IValidator<GetAppealsQuery> _validator;

        public GetAppealsQueryHandler(
            IDriverService driverService,
            IValidator<GetAppealsQuery> validator,
            IGeneralService generalService)
        {
            _driverService = driverService;
            _validator = validator;
            _generalService = generalService;
        }

        public async override Task<GetAppealsQueryResult> Handle(
            GetAppealsQuery request,
            CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                var validationError = _generalService.ProcessValidationError(validationResult);
                return BadRequest(validationError);
            }

            var idError = await _driverService.CheckforIdError(cancellationToken, request.DriverId);
            if (idError != null)
                return BadRequest(idError);

            var driverAppeals = await _driverService.GetAppealsForDriver(cancellationToken, request.DriverId, request.PagingParameters);
            if (driverAppeals.Count == 0)
            {
                var warning = new ExecutionWarning("We couldn't find and retrieve any driver-appeal data.", Constants.WarningCodes.NoData);
                return SucceededWithNoData(warning);
            }

            var result = new GetAppealsQueryResult(driverAppeals);

            if (request.PagingParameters != null)
                result.FillPagingInfo((PaginatedList<AppealDto>)driverAppeals);

            return result;
        }
    }
}
