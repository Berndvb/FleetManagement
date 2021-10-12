using FleetManagement.BLL.Services;
using FluentValidation;
using MediatR.Cqrs.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.WriteAPI.Features.DriverVehicleManagement.AddDriverVehicleConnection
{
    public class AddDriverVehicleCommandHandler : CommandHandler<AddDriverVehicleCommand, AddDriverVehicleCommandResult>
    {
        private readonly IDriverVehicleService _driverVehicleService;
        private readonly IGeneralService _generalService;
        private readonly IValidator<AddDriverVehicleCommand> _validator;

        public AddDriverVehicleCommandHandler(
            IDriverVehicleService driverVehicleService,
            IGeneralService generalService,
            IValidator<AddDriverVehicleCommand> validator)
        {
            _driverVehicleService = driverVehicleService;
            _generalService = generalService;
            _validator = validator;
        }

        public async override Task<AddDriverVehicleCommandResult> Handle(
            AddDriverVehicleCommand request,
            CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                var validationError = _generalService.ProcessValidationError(validationResult);
                return BadRequest(validationError);
            }

            _driverVehicleService.AddDriverVehicle(cancellationToken, request.DriverVehicle);

            return new AddDriverVehicleCommandResult();
        }
    }
}
