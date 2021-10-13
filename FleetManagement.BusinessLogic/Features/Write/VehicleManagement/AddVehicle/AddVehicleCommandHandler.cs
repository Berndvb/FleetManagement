using FleetManagement.BLL.Services;
using FluentValidation;
using MediatR.Cqrs.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Features.Write.VehicleManagement.AddVehicle
{
    public class AddVehicleCommandHandler : CommandHandler<AddVehicleCommand, AddVehicleCommandResult>
    {
        private readonly IVehicleService _vehicleService;
        private readonly IGeneralService _generalService;
        private readonly IValidator<AddVehicleCommand> _validator;

        public AddVehicleCommandHandler(
            IVehicleService vehicleService,
            IGeneralService generalService,
            IValidator<AddVehicleCommand> validator)
        {
            _vehicleService = vehicleService;
            _generalService = generalService;
            _validator = validator;
        }

        public async override Task<AddVehicleCommandResult> Handle(
            AddVehicleCommand request,
            CancellationToken cancellationToken)
        {

            await _vehicleService.AddVehicle(cancellationToken, request.Vehicle);

            return new AddVehicleCommandResult();
        }
    }
}
