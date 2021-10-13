using FleetManagement.BLL.Models.Dtos.WriteDtos;
using MediatR.Cqrs.Commands;

namespace FleetManagement.BLL.Features.Write.DriverVehicleManagement.UpdateDriverVehicle
{
    public class UpdateDriverVehicleCommand : ICommand<UpdateDriverVehicleCommandResult>
    {
        public AddDriverVehicleDto DriverVehicle { get; set; }
    }
}
