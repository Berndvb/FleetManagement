using FleetManagement.Framework.Models.Dtos;
using FleetManagement.Framework.Models.Dtos.ReadDtos;
using MediatR.Cqrs.Commands;

namespace FleetManagement.WriteAPI.Features.FuelCardManagement.UpdateFuelCard
{
    public class UpdateFuelCardCommand : ICommand<UpdateFuelCardCommandResult>
    {
        public FuelCardDto FuelCard { get; set; }
    }
}
