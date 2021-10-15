using FleetManagement.BLL.Models.Dtos.WriteDtos;
using MediatR.Cqrs.Commands;

namespace FleetManagement.BLL.Features.Write.DriverManagement.UpdateDriver
{
    public class UpdateDriverCommand : ICommand<UpdateDriverCommandResult>
    {
        public AddDriverDetailsDto Driver { get; set; }

        public int DriverId { get; set; }
    }
}
