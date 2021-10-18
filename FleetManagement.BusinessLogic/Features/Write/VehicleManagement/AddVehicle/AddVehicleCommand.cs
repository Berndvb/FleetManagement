using FleetManagement.BLL.Models.Dtos.WriteDtos;
using MediatR.Cqrs.Commands;

namespace FleetManagement.BLL.Features.Write.VehicleManagement.AddVehicle
{
    public class AddVehicleCommand : ICommand<AddVehicleCommandResult>
    {
        public AddVehicleDetailsDto Vehicle { get; set; }
    }
}
