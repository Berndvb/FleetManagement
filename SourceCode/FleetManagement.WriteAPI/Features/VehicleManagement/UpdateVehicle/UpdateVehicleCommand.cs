using FleetManagement.Framework.Models.Dtos.ReadDtos;
using MediatR.Cqrs.Commands;

namespace FleetManagement.WriteAPI.Features.VehicleManagement.UpdateVehicle
{
    public class UpdateVehicleCommand : ICommand<UpdateVehicleCommandResult>
    {
        public VehicleDetailsDto Vehicle { get; set; }
    }
}
