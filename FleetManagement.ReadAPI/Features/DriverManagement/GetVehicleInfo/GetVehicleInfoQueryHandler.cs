using FleetManagement.BLL.Services;
using FleetManagement.Framework.Constants;
using FluentValidation;
using MediatR.Cqrs.Execution;
using MediatR.Cqrs.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetVehicleDetails
{
    public class GetVehicleInfoQueryHandler : QueryHandler<GetVehicleInfoQuery, GetVehicleInfoQueryResult>
    {
        private readonly IDriverService _driverService;
        private readonly IGeneralService _generalService;
        private readonly IValidator<GetVehicleInfoQuery> _validator;

        public GetVehicleInfoQueryHandler(
            IDriverService driverService,
            IGeneralService generalService,
            IValidator<GetVehicleInfoQuery> validator)
        {
            _driverService = driverService;
            _generalService = generalService;
            _validator = validator;
        }

        public async override Task<GetVehicleInfoQueryResult> Handle(
            GetVehicleInfoQuery request,
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

            var vehicles = await _driverService.GetVehicleInfoForDriver(request.DriverId, request.PagingParameters);
            if (vehicles.Count == 0)
            {
                var warning = new ExecutionWarning("We couldn't find and retrieve any vehicle data.", Constants.WarningCodes.NoData);
                return SuccesWithNoData(warning);
            }

            return new GetVehicleInfoQueryResult(vehicles);
        }
    }
}
