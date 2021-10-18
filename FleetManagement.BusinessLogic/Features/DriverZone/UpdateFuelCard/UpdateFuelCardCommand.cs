using FleetManagement.BLL.Models.Dtos.ReadDtos;
using MediatR.Cqrs.Commands;

namespace FleetManagement.BLL.Features.DriverZone.UpdateFuelCard
{
    public class UpdateFuelCardCommand : ICommand<UpdateFuelCardCommandResult>
    {
        public FuelCardDto FuelCard { get; set; }

        public int FuelCardId { get; set; }
    }
}
