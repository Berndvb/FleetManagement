using FleetManagement.BLL.Services;
using FluentValidation;
using MediatR.Cqrs.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.WriteAPI.Features.FuelCardManagement.UpdateFuelCardDriver
{
    public class UpdateFuelCardDriverCommandHandler : CommandHandler<UpdateFuelCardDriverCommand, UpdateFuelCardDriverCommandResult>
    {
        private readonly IGeneralService _generalService;
        private readonly IFuelCardDriverService _fuelCardDriverService;
        private readonly IValidator<UpdateFuelCardDriverCommand> _validator;

        public UpdateFuelCardDriverCommandHandler(
            IGeneralService generalService,
            IValidator<UpdateFuelCardDriverCommand> validator,
            IFuelCardDriverService fuelCardDriverService)
        {
            _generalService = generalService;
            _validator = validator;
            _fuelCardDriverService = fuelCardDriverService;
        }

        public async override Task<UpdateFuelCardDriverCommandResult> Handle(
             UpdateFuelCardDriverCommand request,
            CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                var validationError = _generalService.ProcessValidationError(validationResult);
                return BadRequest(validationError);
            }

            _fuelCardDriverService.UpdateFuelCardDriver(request.FuelCardDriver);

            return new UpdateFuelCardDriverCommandResult();
        }
    }
}
