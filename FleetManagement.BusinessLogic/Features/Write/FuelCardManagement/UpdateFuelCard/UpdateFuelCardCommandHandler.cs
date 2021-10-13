using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Services;
using FluentValidation;
using MediatR.Cqrs.Commands;

namespace FleetManagement.BLL.Features.Write.FuelCardManagement.UpdateFuelCard
{
    public class UpdateFuelCardCommandHandler : CommandHandler<UpdateFuelCardCommand, UpdateFuelCardCommandResult>
    {
        private readonly IGeneralService _generalService;
        private readonly IFuelCardService _fuelCardService;
        private readonly IValidator<UpdateFuelCardCommand> _validator;

        public UpdateFuelCardCommandHandler(
            IGeneralService generalService,
            IValidator<UpdateFuelCardCommand> validator,
            IFuelCardService fuelCardService)
        {
            _generalService = generalService;
            _validator = validator;
            _fuelCardService = fuelCardService;
        }

        public async override Task<UpdateFuelCardCommandResult> Handle(
             UpdateFuelCardCommand request,
            CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                var validationError = _generalService.ProcessValidationError(validationResult);
                return BadRequest(validationError);
            }

            _fuelCardService.UpdateFuelCard(cancellationToken, request.FuelCard);

            return new UpdateFuelCardCommandResult();
        }
    }
}