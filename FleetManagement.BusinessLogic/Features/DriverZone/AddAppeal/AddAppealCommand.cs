using FleetManagement.BLL.Models.Dtos.WriteDtos;
using MediatR.Cqrs.Commands;

namespace FleetManagement.BLL.Features.DriverZone.AddAppeal
{
    public class AddAppealCommand : ICommand<AddAppealCommandResult>
    {
        public AddAppealDto Appeal { get; set; }
    }
}
