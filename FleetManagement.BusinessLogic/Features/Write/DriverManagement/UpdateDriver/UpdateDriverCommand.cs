using FleetManagement.BLL.Models.Dtos.ReadDtos;
using MediatR.Cqrs.Commands;

namespace FleetManagement.BLL.Features.Write.DriverManagement.UpdateDriver
{
    public class UpdateDriverCommand : ICommand<UpdateDriverCommandResult>
    {
        public DriverDetailsDto Driver { get; set; }
    }
}
