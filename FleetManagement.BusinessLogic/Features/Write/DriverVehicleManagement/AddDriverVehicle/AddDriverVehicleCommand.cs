using FleetManagement.BLL.Models.Dtos.WriteDtos;
using MediatR.Cqrs.Commands;

namespace FleetManagement.BLL.Features.Write.DriverVehicleManagement.AddDriverVehicle
{
    public class AddDriverVehicleCommand : ICommand<AddDriverVehicleCommandResult>
    {
        public AddDriverVehicleDto DriverVehicle { get; set; }
    }
}
