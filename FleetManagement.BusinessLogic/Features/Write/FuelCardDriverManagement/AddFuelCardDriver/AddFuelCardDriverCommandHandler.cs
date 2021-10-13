using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Services;
using FluentValidation;
using MediatR.Cqrs.Commands;

namespace FleetManagement.BLL.Features.Write.FuelCardDriverManagement.AddFuelCardDriver
{
    public class AddFuelCardDriverCommandHandler : CommandHandler<AddFuelCardDriverCommand, AddFuelCardDriverCommandResult>
    {
        private readonly IFuelCardDriverService _fuelCardDriverService;
        private readonly IGeneralService _generalService;
        private readonly IValidator<AddFuelCardDriverCommand> _validator;

        public AddFuelCardDriverCommandHandler(
            IFuelCardDriverService fuelCardDriverService,
            IGeneralService generalService,
            IValidator<AddFuelCardDriverCommand> validator)
        {
            _fuelCardDriverService = fuelCardDriverService;
            _generalService = generalService;
            _validator = validator;
        }

        public async override Task<AddFuelCardDriverCommandResult> Handle(
            AddFuelCardDriverCommand request,
            CancellationToken cancellationToken)
        {

            var errorCode = await _fuelCardDriverService.HasOtherActiveFuelCardDrivers(cancellationToken, request.FuelCardDriver.FuelCardId, request.FuelCardDriver.DriverId);
            if (errorCode != null)
                BadRequest(errorCode);

            _fuelCardDriverService.AddFuelCardDriver(cancellationToken, request.FuelCardDriver);

            return new AddFuelCardDriverCommandResult();
        }
    }
}

