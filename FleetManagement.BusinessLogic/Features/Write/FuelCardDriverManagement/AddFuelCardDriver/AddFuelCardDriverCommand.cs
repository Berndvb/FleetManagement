using FleetManagement.BLL.Models.Dtos.WriteDtos;
using MediatR.Cqrs.Commands;

namespace FleetManagement.BLL.Features.Write.FuelCardDriverManagement.AddFuelCardDriver
{
    public class AddFuelCardDriverCommand : ICommand<AddFuelCardDriverCommandResult>
    {
        public AddFuelCardDriverDto FuelCardDriver { get; set; }
    }
}
