using FleetManagement.BLL.Models.Dtos.ReadDtos;
using MediatR.Cqrs.Commands;

namespace FleetManagement.BLL.Features.Write.VehicleManagement.UpdateVehicle
{
    public class UpdateVehicleCommand : ICommand<UpdateVehicleCommandResult>
    {
        public VehicleDetailsDto Vehicle { get; set; }

        public int VehicleId { get; set; }
    }
}
