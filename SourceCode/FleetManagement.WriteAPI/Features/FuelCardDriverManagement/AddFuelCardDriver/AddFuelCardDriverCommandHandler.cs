using FleetManagement.BLL.Services;
using FluentValidation;
using MediatR.Cqrs.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.WriteAPI.Features.FuelCardDriverManagement.AddFuelCardDriverConnection
{
    public class AddFuelCardDriverCommandHandler : CommandHandler<AddFuelCardDriverCommand, AddFuelCardDriverCommandResult>
    {
        private readonly IFuelCardDriverService _fuelCardDriver;
        private readonly IGeneralService _generalService;
        private readonly IValidator<AddFuelCardDriverCommand> _validator;

        public AddFuelCardDriverCommandHandler(
            IFuelCardDriverService fuelCardDriver,
            IGeneralService generalService,
            IValidator<AddFuelCardDriverCommand> validator)
        {
            _fuelCardDriver = fuelCardDriver;
            _generalService = generalService;
            _validator = validator;
        }

        public async override Task<AddFuelCardDriverCommandResult> Handle(
            AddFuelCardDriverCommand request,
            CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                var validationError = _generalService.ProcessValidationError(validationResult);
                return BadRequest(validationError);
            }

            _fuelCardDriver.AddFuelCardDriver(request.FuelCardDriver);

            return new AddFuelCardDriverCommandResult();
        }
    }
}

