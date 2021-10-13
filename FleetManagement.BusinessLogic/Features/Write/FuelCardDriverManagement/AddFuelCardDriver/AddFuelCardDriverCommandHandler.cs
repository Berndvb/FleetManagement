using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Services;
using FluentValidation;
using MediatR.Cqrs.Commands;

namespace FleetManagement.BLL.Features.Write.FuelCardDriverManagement.AddFuelCardDriver
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

            _fuelCardDriver.AddFuelCardDriver(cancellationToken, request.FuelCardDriver);

            return new AddFuelCardDriverCommandResult();
        }
    }
}

