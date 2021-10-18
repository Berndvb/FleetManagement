using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Models.Dtos.WriteDtos;
using FleetManagement.Domain.Models;
using FleetManager.EFCore.UOW;
using MediatR.Cqrs.Commands;

namespace FleetManagement.BLL.Features.DriverZone.AddAppeal
{
    public class AddAppealCommandHandler : CommandHandler<AddAppealCommand, AddAppealCommandResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddAppealCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<AddAppealCommandResult> Handle(
            AddAppealCommand request,
            CancellationToken cancellationToken)
        {
            await AddAppeal(request.Appeal, cancellationToken);

            return new AddAppealCommandResult();
        }

        public async Task AddAppeal(AddAppealDto appealDto, CancellationToken cancellationToken)
        {
            var appeal = new Appeal(
                appealDto.CreationDate,
                appealDto.AppealType,
                appealDto.Status,
                appealDto.Vehicle,
                appealDto.Driver,
                appealDto.Repare,
                appealDto.Maintenance,
                appealDto.FirstDatePlanning,
                appealDto.SecondDatePlanning,
                appealDto.Message);

            await _unitOfWork.Appeals.Insert(appeal, cancellationToken);

            _unitOfWork.Complete();
        }
    }
}
