using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Services;
using FluentValidation;
using MediatR.Cqrs.Commands;

namespace FleetManagement.BLL.Features.Write.DriverManagement.RemoveDrives
{
    public class RemoveDriversCommandHandler : CommandHandler<RemoveDrivesCommand, RemoveDrivesCommandResult>
    {
        private readonly IDriverService _driverService;
        private readonly IGeneralService _generalService;
        private readonly IValidator<RemoveDrivesCommand> _validator;

        public RemoveDriversCommandHandler(
            IDriverService driverService,
            IGeneralService generalService,
            IValidator<RemoveDrivesCommand> validator)
        {
            _driverService = driverService;
            _generalService = generalService;
            _validator = validator;
        }

        public async override Task<RemoveDrivesCommandResult> Handle(
            RemoveDrivesCommand request,
            CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                var validationError = _generalService.ProcessValidationError(validationResult);
                return BadRequest(validationError);
            }

            _driverService.RemoveDriver(cancellationToken, request.Driver);

            return new RemoveDrivesCommandResult();
        }
    }
}
