using AutoMapper;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManagement.Domain.Interfaces.Repositories;
using MediatR.Cqrs.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Features.Write.FuelCardManagement.UpdateFuelCard
{
    public class UpdateFuelCardCommandHandler : CommandHandler<UpdateFuelCardCommand, UpdateFuelCardCommandResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateFuelCardCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
            var fuelCard = await _unitOfWork.FuelCards.GetBy(
                cancellationToken,
                filter: x => x.Id.Equals(fuelCardId));

            fuelCard.AuthenticationType = fuelCardDto.AuthenticationType;
            fuelCard.Blocked = fuelCardDto.Blocked;
            fuelCard.Pincode = fuelCardDto.Pincode;

            await Task.Run(() => _unitOfWork.FuelCards.Update(cancellationToken, fuelCard));

            _unitOfWork.Complete();
        }
    }
}