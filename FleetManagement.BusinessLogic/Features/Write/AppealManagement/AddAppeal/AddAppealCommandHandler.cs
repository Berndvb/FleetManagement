using AutoMapper;
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
        private readonly IMapper _mapper;

        public AddAppealCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async override Task<AddAppealCommandResult> Handle(
            AddAppealCommand request,
            CancellationToken cancellationToken)
        {

            await AddAppeal(cancellationToken, request.Appeal);

            return new AddAppealCommandResult();
        }

        public async Task AddAppeal(CancellationToken cancellationToken, AddAppealDto AppealDto)
        {
            var appeal = _mapper.Map<Appeal>(AppealDto);

            await _unitOfWork.Appeals.Insert(cancellationToken, appeal);

            _unitOfWork.Complete();
        }
    }
}
