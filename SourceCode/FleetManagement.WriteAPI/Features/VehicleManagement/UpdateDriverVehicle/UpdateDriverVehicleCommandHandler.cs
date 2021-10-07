using FleetManagement.BLL.Services;
using FluentValidation;
using MediatR.Cqrs.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.WriteAPI.Features.VehicleManagement.UpdateDriverVehicle
{
    public class UpdateDriverVehicleCommandHandler : CommandHandler<UpdateDriverVehicleCommand, UpdateDriverVehicleCommandResult>
    {
        private readonly IDriverVehicleService _driverVehicleService;
        private readonly IGeneralService _generalService;
        private readonly IValidator<UpdateDriverVehicleCommand> _validator;

        public UpdateDriverVehicleCommandHandler(
            IDriverVehicleService driverVehicleService,
            IGeneralService generalService,
            IValidator<UpdateDriverVehicleCommand> validator)
        {
            _driverVehicleService = driverVehicleService;
            _generalService = generalService;
            _validator = validator;
        }

        public async override Task<UpdateDriverVehicleCommandResult> Handle(
             UpdateDriverVehicleCommand request,
            CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                var validationError = _generalService.ProcessValidationError(validationResult);
                return BadRequest(validationError);
            }

            _driverVehicleService.UpdateDriverVehicle(request.DriverVehicle);

            return new UpdateDriverVehicleCommandResult();
        }
    }
}
