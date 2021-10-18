using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManager.EFCore.UOW;
using MediatR.Cqrs.Commands;

namespace FleetManagement.BLL.Features.DriverZone.UpdateFuelCard
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
            await UpdateFuelCard(
                request.FuelCard,
                request.FuelCardId, 
                cancellationToken);

            return new UpdateFuelCardCommandResult();
        }

        public async Task UpdateFuelCard(
            FuelCardDto fuelCardDto, 
            int fuelCardId, 
            CancellationToken cancellationToken)
        {
            var fuelCard = await _unitOfWork.FuelCards.GetBy(
                cancellationToken,
                filter: x => x.Id.Equals(fuelCardId));

            fuelCard.ChangeFuelCardInfoForDriver(
                fuelCardDto.AuthenticationType, 
                fuelCardDto.Blocked, 
                fuelCardDto.Pincode);

            await Task.Run(() => _unitOfWork.FuelCards.Update(fuelCard, cancellationToken));

            _unitOfWork.Complete();
        }
    }
}