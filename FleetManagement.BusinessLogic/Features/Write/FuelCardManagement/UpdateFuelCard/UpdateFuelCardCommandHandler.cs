using AutoMapper;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManagement.Domain.Interfaces.Repositories;
using FleetManagement.Domain.Models;
using MediatR.Cqrs.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Features.Write.FuelCardManagement.UpdateFuelCard
{
    public class UpdateFuelCardCommandHandler : CommandHandler<UpdateFuelCardCommand, UpdateFuelCardCommandResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateFuelCardCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async override Task<UpdateFuelCardCommandResult> Handle(
             UpdateFuelCardCommand request,
            CancellationToken cancellationToken)
        {
            await UpdateFuelCard(cancellationToken, request.FuelCard, request.FuelCardId);

            return new UpdateFuelCardCommandResult();
        }

        public async Task UpdateFuelCard(CancellationToken cancellationToken, FuelCardDto fuelCardDto, int fuelCardId)
        {
            var fuelCard = _mapper.Map<FuelCard>(fuelCardDto);

            await Task.Run(() => _unitOfWork.FuelCards.Update(cancellationToken, fuelCard, fuelCardId));

            _unitOfWork.Complete();
        }
    }
}