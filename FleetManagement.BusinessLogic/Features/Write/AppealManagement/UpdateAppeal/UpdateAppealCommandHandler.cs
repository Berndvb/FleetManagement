using FleetManagement.BLL.Models.Dtos.WriteDtos;
using FleetManagement.Domain.Interfaces.Repositories;
using MediatR.Cqrs.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Features.Write.AppealManagement.UpdateAppeal
{
    public class UpdateAppealCommandHandler : CommandHandler<UpdateAppealCommand, UpdateAppealCommandResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAppealCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<UpdateAppealCommandResult> Handle(
             UpdateAppealCommand request,
            CancellationToken cancellationToken)
        {
            await UpdateAppeal(cancellationToken, request.Appeal, request.AppealId);

            return new UpdateAppealCommandResult();
        }

        public async Task UpdateAppeal(
            CancellationToken cancellationToken, 
            AddAppealDto appealDto, 
            int appealId)
        {
            var appeal = await _unitOfWork.Appeals.GetBy(
                cancellationToken,
                filter: x => x.Id.Equals(appealId));

            appeal.AppealType = appealDto.AppealType;
            appeal.FirstDatePlanning = appealDto.FirstDatePlanning;
            appeal.SecondDatePlanning = appealDto.SecondDatePlanning;
            appeal.Message = appealDto.Message;

            await _unitOfWork.Appeals.Update(cancellationToken, appeal);

            _unitOfWork.Complete();
        }
    }
}
