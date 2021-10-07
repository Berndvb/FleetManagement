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
        // YO I still need the fuelcarddriver info added to this call - we need both!
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

            var fuelCardDtos = await _driverService.GetFuelCardsForDriver(request.DriverId);
            if (fuelCardDtos.Count == 0)
            {
                var dataError = new ExecutionError("We couldn't find and retrieve any driver-fuelcard data.", Constants.ErrorCodes.DataNotFound);
                return NotFound(dataError);
            }
            
            return new GetFuelCardsQueryResult(fuelCardDtos);
        }
    }
}
