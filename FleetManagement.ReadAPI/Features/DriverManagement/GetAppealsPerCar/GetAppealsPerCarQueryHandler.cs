using FleetManagement.BLL.Services;
using FleetManagement.Framework.Constants;
using FluentValidation;
using MediatR.Cqrs.Execution;
using MediatR.Cqrs.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetAppealsPerCar
{
    public class GetAppealsPerCarQueryHandler : QueryHandler<GetAppealsPerCarQuery, GetAppealsPerCarQueryResult>
    {
        private readonly IDriverService _driverService;
        private readonly IGeneralService _generalService;
        private readonly IVehicleService _vehicleService;
        private readonly IValidator<GetAppealsPerCarQuery> _validator;

        public GetAppealsPerCarQueryHandler(
            IDriverService driverService,
            IGeneralService generalService,
            IValidator<GetAppealsPerCarQuery> validator,
            IVehicleService vehicleService)
        {
            _driverService = driverService;
            _generalService = generalService;
            _validator = validator;
            _vehicleService = vehicleService;
        }

        public async override Task<GetAppealsPerCarQueryResult> Handle(
            GetAppealsPerCarQuery request,
            CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                var validationError = _generalService.ProcessValidationError(validationResult);
                return BadRequest(validationError);
            }

            var driverIdError = await _driverService.CheckforIdError(request.DriverId);
            if (driverIdError != null)
                return BadRequest(driverIdError);

            var vehicleIdError = await _vehicleService.CheckforIdError(request.VehicleId);
            if (vehicleIdError != null)
                return BadRequest(vehicleIdError);

            var vehicleAppeals = await _driverService.GetAppealsForDriverPerCar(request.DriverId, request.VehicleId, request.PagingParameters);
            if (vehicleAppeals.Count == 0)
            {
                var warning = new ExecutionWarning("We couldn't find and retrieve any appeal data.", Constants.WarningCodes.NoData);
                return SuccesWithNoData(warning);
            }

            return new GetAppealsPerCarQueryResult(vehicleAppeals);
        }
    }
}
