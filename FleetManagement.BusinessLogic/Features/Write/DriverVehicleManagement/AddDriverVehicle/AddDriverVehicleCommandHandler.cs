using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Services;
using FluentValidation;
using MediatR.Cqrs.Commands;

namespace FleetManagement.BLL.Features.Write.DriverVehicleManagement.AddDriverVehicle
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
            var errorCode = await _driverVehicleService.HasOtherActiveDriverVehicles(cancellationToken, request.DriverVehicle.VehicleId, request.DriverVehicle.DriverId);
            if (errorCode != null)
                BadRequest(errorCode);

            _driverVehicleService.AddDriverVehicle(cancellationToken, request.DriverVehicle);

            return new AddDriverVehicleCommandResult();
        }
    }
}
