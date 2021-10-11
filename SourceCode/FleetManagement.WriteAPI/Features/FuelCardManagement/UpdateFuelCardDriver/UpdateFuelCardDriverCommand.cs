using FleetManagement.Framework.Models.Dtos;
using FleetManagement.Framework.Models.Dtos.ReadDtos;
using MediatR.Cqrs.Commands;

namespace FleetManagement.WriteAPI.Features.FuelCardManagement.UpdateFuelCardDriver
{
    public class UpdateFuelCardDriverCommand : ICommand<UpdateFuelCardDriverCommandResult>
    {
        public FuelCardDriverDto FuelCardDriver { get; set; }
    }
}
