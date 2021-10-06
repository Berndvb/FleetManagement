using FleetManagement.BLL.Services;
using MediatR.Cqrs.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.WriteAPI.Features.VehicleManagement.UpdateDriverVehicle
{
    public class UpdateDriverVehicleCommandHandler : CommandHandler<UpdateDriverVehicleCommand, UpdateDriverVehicleCommandResult>
    {
        private readonly IDriverVehicleService _driverVehicleService;

        public UpdateDriverVehicleCommandHandler(
            IDriverVehicleService driverVehicleService)
        {
            _driverVehicleService = driverVehicleService;
        }

        public async override Task<UpdateDriverVehicleCommandResult> Handle(
             UpdateDriverVehicleCommand request,
            CancellationToken cancellationToken)
        {
            _driverVehicleService.UpdateDriverVehicle(request.DriverVehicle);

            return new UpdateDriverVehicleCommandResult();
        }
    }
}
