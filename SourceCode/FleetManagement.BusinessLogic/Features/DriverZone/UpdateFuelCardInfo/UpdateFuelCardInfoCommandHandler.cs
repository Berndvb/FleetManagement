using System.Threading;
using System.Threading.Tasks;
using FleetManager.EFCore.UOW;
using MediatR.Cqrs.Commands;

namespace FleetManagement.BLL.Features.DriverZone.UpdateFuelCardInfo
{
    public class UpdateFuelCardInfoCommandHandler : CommandHandler<UpdateFuelCardInfoCommand, UpdateFuelCardInfoCommandResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateFuelCardInfoCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<UpdateFuelCardInfoCommandResult> Handle(
            UpdateFuelCardInfoCommand request,
            CancellationToken cancellationToken)
        {
            await UpdateFuelCard(request, cancellationToken);

            return new UpdateFuelCardInfoCommandResult();
        }

        private async Task UpdateFuelCard(
            UpdateFuelCardInfoCommand request,
            CancellationToken cancellationToken)
        {
            var fuelCard = await _unitOfWork.FuelCards.GetBy(
                cancellationToken,
                filter: x => x.Id.Equals(request.FuelCardId));

            fuelCard.AuthenticationType = request.AuthenticationType;
            fuelCard.Blocked = request.Blocked;
            fuelCard.Pincode = request.Pincode;

            await _unitOfWork.FuelCards.Update(fuelCard, cancellationToken);

            _unitOfWork.Complete();
        }
    }
}