using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Models.Dtos.WriteDtos;
using FleetManager.EFCore.UOW;
using MediatR.Cqrs.Commands;

namespace FleetManagement.BLL.Features.DriverZone.UpdateAppeal
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
            await UpdateAppeal(
                request.Appeal, 
                request.AppealId, 
                cancellationToken);

            return new UpdateAppealCommandResult();
        }

        public async Task UpdateAppeal(
            AddAppealDto appealDto, 
            int appealId,
            CancellationToken cancellationToken)
        {
            var appeal = await _unitOfWork.Appeals.GetBy(
                cancellationToken,
                filter: x => x.Id.Equals(appealId));

            appeal.ChangeAppealInfoForDriver(
                appealDto.AppealType,
                appealDto.FirstDatePlanning,
                appealDto.SecondDatePlanning,
                appealDto.Message);

            await _unitOfWork.Appeals.Update(appeal, cancellationToken);

            _unitOfWork.Complete();
        }
    }
}
