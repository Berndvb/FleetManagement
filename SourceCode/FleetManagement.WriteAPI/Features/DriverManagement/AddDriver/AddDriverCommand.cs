using FleetManagement.Framework.Models.Dtos.ShowDtos;
using MediatR.Cqrs.Commands;

namespace FleetManagement.WriteAPI.Features.DriverManagement.AddDriver
{
    public class AddDriverCommand : ICommand<AddDriverCommandResult>
    {
        public DriverDetailsDto Driver { get; set; }
    }
}
