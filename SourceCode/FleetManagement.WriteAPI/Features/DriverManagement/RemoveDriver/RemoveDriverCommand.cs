using FleetManagement.Framework.Models.Dtos.ReadDtos;
using MediatR.Cqrs.Commands;

namespace FleetManagement.WriteAPI.Features.DriverManagement.RemoveDriver
{
    public class RemoveDriverCommand : ICommand<RemoveDriverCommandResult>
    {
        public DriverDetailsDto Driver { get; set; }
    }
}
