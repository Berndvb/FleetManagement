using FleetManagement.BLL.Services;
using MediatR.Cqrs.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.WriteAPI.Features.VehicleManagement.UpdateVehicle
{
    public class UpdateVehicleCommandHandler : CommandHandler<UpdateVehicleCommand, UpdateVehicleCommandResult>
    {
        private readonly IVehicleService _VehicleService;

        public UpdateVehicleCommandHandler(
            IVehicleService vehicleService)
        {
            _VehicleService = vehicleService;
        }

        public async override Task<UpdateVehicleCommandResult> Handle(
             UpdateVehicleCommand request,
            CancellationToken cancellationToken)
        {
            _VehicleService.UpdateVehicle(request.Vehicle);

            return new UpdateVehicleCommandResult();
        }
    }
}
