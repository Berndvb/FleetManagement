using FleetManagement.BLL.Models.Dtos.ReadDtos;
using MediatR.Cqrs.Commands;

namespace FleetManagement.BLL.Features.Write.FuelCardDriverManagement.UpdateFuelCardDriver
{
    public class UpdateFuelCardDriverCommand : ICommand<UpdateFuelCardDriverCommandResult>
    {
        public FuelCardDriverDto FuelCardDriver { get; set; }

        public int FuelCardDriverId { get; set; }
    }
}
