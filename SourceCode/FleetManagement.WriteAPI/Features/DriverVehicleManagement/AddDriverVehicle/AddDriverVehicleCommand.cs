using FleetManagement.Framework.Models.Dtos;
using FleetManagement.Framework.Models.Dtos.WriteDtos;
using FleetManagement.Framework.Models.WriteDtos;
using MediatR.Cqrs.Commands;

namespace FleetManagement.WriteAPI.Features.DriverVehicleManagement.AddDriverVehicleConnection
{
    public class AddDriverVehicleCommand : ICommand<AddDriverVehicleCommandResult>
    {
        public AddDriverVehicleDto DriverVehicle { get; set; }
    }
}
