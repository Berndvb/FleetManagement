using FleetManagement.BLL.Models.Dtos.ReadDtos;
using MediatR.Cqrs.Commands;

namespace FleetManagement.BLL.Features.Write.DriverManagement.RemoveDrives
{
    public class RemoveDrivesCommand : ICommand<RemoveDrivesCommandResult>
    {
        public DriverDetailsDto Driver { get; set; }
    }
}
