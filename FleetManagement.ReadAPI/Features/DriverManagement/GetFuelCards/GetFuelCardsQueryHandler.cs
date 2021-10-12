using FleetManagement.BLL.Services;
using FleetManagement.Framework.Constants;
using FluentValidation;
using MediatR.Cqrs.Execution;
using MediatR.Cqrs.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetFuelCardDetails
{
    public class GetFuelCardsQueryHandler : QueryHandler<GetFuelCardsQuery, GetFuelCardsQueryResult>
    {
        private readonly IDriverService _driverService;
        private readonly IGeneralService _generalService;
        private readonly IValidator<GetFuelCardsQuery> _validator;

        public GetFuelCardsQueryHandler(
            IDriverService driverService,
            IGeneralService generalService,
            IValidator<GetFuelCardsQuery> validator)
        {
            _driverService = driverService;
            _generalService = generalService;
            _validator = validator;
        }

        public async override Task<GetFuelCardsQueryResult> Handle(
            GetFuelCardsQuery request,
            CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                var validationError = _generalService.ProcessValidationError(validationResult);
                return BadRequest(validationError);
            }

            var idError = await _driverService.CheckforIdError(request.DriverId);
            if (idError != null)
                return BadRequest(idError);

            var fuelCardDtos = await _driverService.GetFuelCardsForDriver(request.DriverId, request.PagingParameters);
            if (fuelCardDtos.Count == 0)
            {
                var warning = new ExecutionWarning("We couldn't find and retrieve any fuelcard data.", Constants.WarningCodes.NoData);
                return SuccesWithNoData(warning);
            }
            
            return new GetFuelCardsQueryResult(fuelCardDtos);
        }
    }
}
