using FleetManagement.BLL.Services;
using FluentValidation;
using MediatR.Cqrs.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.WriteAPI.Features.VehicleManagement.UpdateVehicle
{
    public class UpdateVehicleCommandHandler : CommandHandler<UpdateVehicleCommand, UpdateVehicleCommandResult>
    {
        private readonly IVehicleService _vehicleService;
        private readonly IGeneralService _generalService;
        private readonly IValidator<UpdateVehicleCommand> _validator;

        public UpdateVehicleCommandHandler(
            IVehicleService vehicleService,
            IGeneralService generalService,
            IValidator<UpdateVehicleCommand> validator)
        {
            _vehicleService = vehicleService;
            _generalService = generalService;
            _validator = validator;
        }

        public async override Task<UpdateVehicleCommandResult> Handle(
             UpdateVehicleCommand request,
            CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                var validationError = _generalService.ProcessValidationError(validationResult);
                return BadRequest(validationError);
            }

            _vehicleService.UpdateVehicle(request.Vehicle);

            return new UpdateVehicleCommandResult();
        }
    }
}
