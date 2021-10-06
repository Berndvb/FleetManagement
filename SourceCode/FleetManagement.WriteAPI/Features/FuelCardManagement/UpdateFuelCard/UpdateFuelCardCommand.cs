using FleetManagement.Framework.Models.Dtos;
using MediatR.Cqrs.Commands;

namespace FleetManagement.WriteAPI.Features.FuelCardManagement.UpdateFuelCard
{
    public class UpdateFuelCardCommand : ICommand<UpdateFuelCardCommandResult>
    {
        public string FuelCardId { get; set; }

        public FuelCardDto FuelCard { get; set; }
    }
}
