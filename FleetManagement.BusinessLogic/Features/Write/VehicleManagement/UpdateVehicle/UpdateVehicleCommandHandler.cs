using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Services;
using FluentValidation;
using MediatR.Cqrs.Commands;

namespace FleetManagement.BLL.Features.Write.VehicleManagement.UpdateVehicle
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
            await _vehicleService.UpdateVehicle(cancellationToken, request.Vehicle, request.VehicleId);

            return new UpdateVehicleCommandResult();
        }
    }
}
