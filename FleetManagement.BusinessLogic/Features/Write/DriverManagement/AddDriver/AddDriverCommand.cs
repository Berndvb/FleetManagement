using FleetManagement.BLL.Models.Dtos.ReadDtos;
using MediatR.Cqrs.Commands;

namespace FleetManagement.BLL.Features.Write.DriverManagement.AddDriver
{
    public class AddDriverCommand : ICommand<AddDriverCommandResult>
    {
        public DriverDetailsDto Driver { get; set; }
    }
}
