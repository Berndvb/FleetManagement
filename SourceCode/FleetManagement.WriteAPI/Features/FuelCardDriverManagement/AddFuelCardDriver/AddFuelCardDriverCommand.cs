using FleetManagement.Framework.Models.WriteDtos;
using MediatR.Cqrs.Commands;

namespace FleetManagement.WriteAPI.Features.FuelCardDriverManagement.AddFuelCardDriverConnection
{
    public class AddFuelCardDriverCommand : ICommand<AddFuelCardDriverCommandResult>
    {
        public AddFuelCardDriverDto FuelCardDriver { get; set; }
    }
}
