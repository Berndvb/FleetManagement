using FleetManagement.BLL.Services;
using FleetManagement.WriteAPI.Features.FuelCardManagement.UpdateFuelCard;
using MediatR.Cqrs.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.WriteAPI.Features.DriverManagement.UpdateDriver
{
    public class UpdateFuelCardCommandHandler : CommandHandler<UpdateFuelCardCommand, UpdateFuelCardCommandResult>
    {
        private readonly IFuelCardService _fuelCardService;

        public UpdateFuelCardCommandHandler(
            IFuelCardService fuelCardService)
        {
            _fuelCardService = fuelCardService;
        }

        public async override Task<UpdateFuelCardCommandResult> Handle(
             UpdateFuelCardCommand request,
            CancellationToken cancellationToken)
        {
            _fuelCardService.UpdateFuelCard(request.FuelCard);

            return new UpdateFuelCardCommandResult();
        }
    }
}