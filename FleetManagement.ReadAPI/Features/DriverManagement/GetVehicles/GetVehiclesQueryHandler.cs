using FleetManagement.BLL.Services;
using FleetManagement.Framework.Constants;
using FluentValidation;
using MediatR.Cqrs.Execution;
using MediatR.Cqrs.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetVehicleDetails
{
    public class GetVehiclesQueryHandler : QueryHandler<GetVehiclesQuery, GetVehiclesQueryResult>
    {
        private readonly IDriverService _driverService;
        private readonly IGeneralService _generalService;
        private readonly IValidator<GetVehiclesQuery> _validator;

        public GetVehiclesQueryHandler(
            IDriverService driverService,
            IGeneralService generalService,
            IValidator<GetVehiclesQuery> validator)
        {
            _driverService = driverService;
            _generalService = generalService;
            _validator = validator;
        }

        public async override Task<GetVehiclesQueryResult> Handle(
            GetVehiclesQuery request,
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

            var vehicles = await _driverService.GetVehiclesForDriver(request.DriverId);
            if (vehicles.Count == 0)
            {
                var dataError = new ExecutionError("We couldn't find and retrieve any driver-vehicle data.", Constants.ErrorCodes.DataNotFound);
                return NotFound(dataError);
            }

            return new GetVehiclesQueryResult(vehicles);
        }
    }
}
