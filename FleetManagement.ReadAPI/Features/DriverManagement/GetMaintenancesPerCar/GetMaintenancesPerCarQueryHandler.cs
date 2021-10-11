using FleetManagement.BLL.Services;
using FleetManagement.Framework.Constants;
using FluentValidation;
using MediatR.Cqrs.Execution;
using MediatR.Cqrs.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetMaintenancesPerCar
{
    public class GetMaintenancesPerCarQueryHandler : QueryHandler<GetMaintenancesPerCarQuery, GetMaintenancesPerCarQueryResult>
    {
        private readonly IDriverService _driverService;
        private readonly IGeneralService _generalService;
        private readonly IVehicleService _vehicleService;
        private readonly IValidator<GetMaintenancesPerCarQuery> _validator;

        public GetMaintenancesPerCarQueryHandler(
            IDriverService driverService,
            IGeneralService generalService,
            IVehicleService vehicleService,
            IValidator<GetMaintenancesPerCarQuery> validator)
        {
            _driverService = driverService;
            _generalService = generalService;
            _vehicleService = vehicleService;
            _validator = validator;
        }

        public async override Task<GetMaintenancesPerCarQueryResult> Handle(
            GetMaintenancesPerCarQuery request,
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

            var vehicleMaintenances = await _driverService.GetMaintenancesForDriverPerCar(request.DriverId, request.VehicleId, request.PagingParameters);
            if (vehicleMaintenances.Count == 0)
            {
                var dataError = new ExecutionError("We couldn't find and retrieve any driver-maintenance data.", Constants.ErrorCodes.DataNotFound);
                return NotFound(dataError);
            }

            return new GetMaintenancesPerCarQueryResult(vehicleMaintenances);
        }
    }
}
