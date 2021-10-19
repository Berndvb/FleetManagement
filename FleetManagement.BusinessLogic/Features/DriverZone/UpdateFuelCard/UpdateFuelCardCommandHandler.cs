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
            await UpdateFuelCard(request, cancellationToken);

            return new UpdateFuelCardCommandResult();
        }

        public async Task UpdateFuelCard(
            UpdateFuelCardCommand request,
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