using FleetManagement.Framework.Models.Dtos.ReadDtos;
using MediatR.Cqrs.Commands;

namespace FleetManagement.WriteAPI.Features.VehicleManagement.UpdateDriverVehicle
{
    public class UpdateDriverVehicleCommand : ICommand<UpdateDriverVehicleCommandResult>
    {
        public DriverVehicleDto DriverVehicle { get; set; }
    }
}
