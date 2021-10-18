using FleetManagement.BLL.Models.Dtos.WriteDtos;
using MediatR.Cqrs.Commands;

namespace FleetManagement.BLL.Features.Write.AppealManagement.UpdateAppeal
{
    public class UpdateAppealCommand : ICommand<UpdateAppealCommandResult>
    {
        public AddAppealDto Appeal { get; set; }

        public int AppealId { get; set; }
    }
}
