using FleetManagement.Framework.Models.Dtos;
using MediatR.Cqrs.Commands;

namespace FleetManagement.WriteAPI.Features.VehicleManagement.UpdateDriverVehicle
{
    public class UpdateDriverVehicleCommand : ICommand<UpdateDriverVehicleCommandResult>
    {
        public string DriverVehicleId { get; set; }

        public DriverVehicleDto DriverVehicle { get; set; }
    }
}
