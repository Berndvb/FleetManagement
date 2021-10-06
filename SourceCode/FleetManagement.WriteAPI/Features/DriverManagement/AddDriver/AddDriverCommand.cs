using FleetManagement.Framework.Models.Dtos;
using MediatR.Cqrs.Commands;

namespace FleetManagement.WriteAPI.Features.DriverManagement.AddDriver
{
    public class AddDriverCommand : ICommand<AddDriverCommandResult>
    {
        public DriverDto Driver { get; set; }
    }
}
