using FleetManagement.BLL.Models.Dtos.ReadDtos;
using MediatR.Cqrs.Commands;

namespace FleetManagement.BLL.Features.Write.DriverVehicleManagement.UpdateDriverVehicle
{
    public class UpdateDriverVehicleCommand : ICommand<UpdateDriverVehicleCommandResult>
    {
        public DriverVehicleDto DriverVehicle { get; set; }

        public int DriverVehicleId { get; set; }
    }
}
