using FleetManager.EFCore.UOW;
using MediatR.Cqrs.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Features.DriverZone.UpdateAppeal
{
    public class UpdateAppealInfoCommandHandler : CommandHandler<UpdateAppealInfoCommand, UpdateAppealInfoCommandResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAppealInfoCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<UpdateAppealInfoCommandResult> Handle(
            UpdateAppealInfoCommand request,
            CancellationToken cancellationToken)
        {
            await UpdateAppealInfo(request, cancellationToken);

            return new UpdateAppealInfoCommandResult();
        }

        private async Task UpdateAppealInfo(
            UpdateAppealInfoCommand request, 
            CancellationToken cancellationToken)
        {
            var appeal = await _unitOfWork.Appeals.GetBy(
                cancellationToken,
                filter: x => x.Id.Equals(request.AppealId));

            appeal.AppealType = request.AppealType;
            appeal.FirstDatePlanning = request.FirstDatePlanning; 
            appeal.SecondDatePlanning = request.SecondDatePlanning; 
            appeal.Message = request.Message;

            await _unitOfWork.Appeals.Update(appeal, cancellationToken);

            _unitOfWork.Complete();
        }
    }
}
