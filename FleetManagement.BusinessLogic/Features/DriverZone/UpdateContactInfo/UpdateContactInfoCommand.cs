using FleetManagement.BLL.Models.Dtos.WriteDtos;
using MediatR.Cqrs.Commands;

namespace FleetManagement.BLL.Features.DriverZone.UpdateContactInfo
{
    public class UpdateContactInfoCommand : ICommand<UpdateContactInfoCommandResult>
    {
        public AddDriverDetailsDto Driver { get; set; }

        public int DriverId { get; set; }
    }
}
