using FleetManagement.Framework.Models.Dtos.WriteDtos;
using MediatR.Cqrs.Commands;

namespace FleetManagement.WriteAPI.Features.DriverManagement.AddDriver
{
    public class AddDriverCommand : ICommand<AddDriverCommandResult>
    {
        public AddDriverDto Driver { get; set; }
    }
}
