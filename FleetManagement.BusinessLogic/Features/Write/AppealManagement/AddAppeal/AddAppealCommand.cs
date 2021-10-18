using FleetManagement.BLL.Models.Dtos.WriteDtos;
using MediatR.Cqrs.Commands;

namespace FleetManagement.BLL.Features.Write.FuelCardManagement.AddFuelCard
{
    public class AddAppealCommand : ICommand<AddAppealCommandResult>
    {
        public AddAppealDto Appeal { get; set; }
    }
}
