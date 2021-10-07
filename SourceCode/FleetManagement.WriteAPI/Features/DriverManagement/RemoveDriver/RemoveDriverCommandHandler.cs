using FleetManagement.BLL.Services;
using FluentValidation;
using MediatR.Cqrs.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.WriteAPI.Features.DriverManagement.RemoveDriver
{
    public class RemoveDriverCommandHandler : CommandHandler<RemoveDriverCommand, RemoveDriverCommandResult>
    {
        private readonly IDriverService _driverService;
        private readonly IGeneralService _generalService;
        private readonly IValidator<RemoveDriverCommand> _validator;

        public RemoveDriverCommandHandler(
            IDriverService driverService,
            IGeneralService generalService,
            IValidator<RemoveDriverCommand> validator)
        {
            _driverService = driverService;
            _generalService = generalService;
            _validator = validator;
        }

        public async override Task<RemoveDriverCommandResult> Handle(
            RemoveDriverCommand request,
            CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                var validationError = _generalService.ProcessValidationError(validationResult);
                return BadRequest(validationError);
            }

            _driverService.RemoveDriver(request.Driver);

            return new RemoveDriverCommandResult();
        }
    }
}
