using FleetManagement.Framework.Models.Dtos;
using MediatR.Cqrs.Commands;

namespace FleetManagement.WriteAPI.Features.FuelCardManagement.UpdateFuelCardDriver
{
    public class UpdateFuelCardDriverCommand : ICommand<UpdateFuelCardDriverCommandResult>
    {
        public string FuelCardDriverId { get; set; }

        public FuelCardDriverDto FuelCardDriver { get; set; }
    }
}
