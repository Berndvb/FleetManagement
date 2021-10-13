using FleetManagement.BLL.Services;
using FluentValidation;
using MediatR.Cqrs.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Features.Write.FuelCardManagement.AddFuelCard
{
    public class AddFuelCardDriverCommandHandler : CommandHandler<AddFuelCardCommand, AddFuelCardCommandResult>
    {
        private readonly IFuelCardService _fuelCard;
        private readonly IGeneralService _generalService;
        private readonly IValidator<AddFuelCardCommand> _validator;

        public AddFuelCardDriverCommandHandler(
            IFuelCardService fuelCardDriver,
            IGeneralService generalService,
            IValidator<AddFuelCardCommand> validator)
        {
            _fuelCard = fuelCardDriver;
            _generalService = generalService;
            _validator = validator;
        }

        public async override Task<AddFuelCardCommandResult> Handle(
            AddFuelCardCommand request,
            CancellationToken cancellationToken)
        {

            await _fuelCard.AddFuelCard(cancellationToken, request.FuelCard);

            return new AddFuelCardCommandResult();
        }
    }
}
