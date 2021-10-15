using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Services;
using FluentValidation;
using MediatR.Cqrs.Commands;

namespace FleetManagement.BLL.Features.Write.DriverVehicleManagement.UpdateDriverVehicle
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
            _driverVehicleService.UpdateDriverVehicle(cancellationToken, request.DriverVehicle, request.DriverVehicleId);

            return new UpdateDriverVehicleCommandResult();
        }
    }
}
