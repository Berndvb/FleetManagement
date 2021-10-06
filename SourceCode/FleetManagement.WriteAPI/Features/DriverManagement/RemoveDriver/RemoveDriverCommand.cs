using FleetManagement.Framework.Models.Dtos;
using MediatR.Cqrs.Commands;

namespace FleetManagement.WriteAPI.Features.DriverManagement.RemoveDriver
{
    public class RemoveDriverCommand : ICommand<RemoveDriverCommandResult>
    {
        public DriverDto Driver { get; set; }
    }
}
