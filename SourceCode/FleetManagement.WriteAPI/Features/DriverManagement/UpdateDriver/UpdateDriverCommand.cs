using FleetManagement.Framework.Models.Dtos.ReadDtos;
using MediatR.Cqrs.Commands;

namespace FleetManagement.WriteAPI.Features.DriverManagement.UpdateDriver
{
    public class UpdateDriverCommand : ICommand<UpdateDriverCommandResult>
    {
        public DriverDetailsDto Driver { get; set; }
    }
}
