using FleetManagement.BLL.Models.Dtos.WriteDtos;
using MediatR.Cqrs.Commands;

namespace FleetManagement.BLL.Features.Write.FuelCardManagement.AddFuelCard
{
    public class AddFuelCardCommand : ICommand<AddFuelCardCommandResult>
    {
        public AddFuelCardDto FuelCard { get; set; }
    }
}
