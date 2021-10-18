using FleetManagement.BLL.Models.Dtos.WriteDtos;
using FleetManagement.Domain.Interfaces.Repositories;
using FleetManagement.Domain.Models;
using MediatR.Cqrs.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Features.Write.FuelCardManagement.AddFuelCard
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
            await AddAppeal(cancellationToken, request.Appeal);

            return new AddAppealCommandResult();
        }

        public async Task AddAppeal(CancellationToken cancellationToken, AddAppealDto appealDto)
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

            await _unitOfWork.Appeals.Insert(cancellationToken, appeal);

            _unitOfWork.Complete();
        }
    }
}
