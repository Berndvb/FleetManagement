using FleetManagement.BLL.Services;
using FluentValidation;
using MediatR.Cqrs.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.WriteAPI.Features.DriverManagement.UpdateDriver
{
    public class UpdateDriverCommandHandler : CommandHandler<UpdateDriverCommand, UpdateDriverCommandResult>
    {
        private readonly IDriverService _driverService;
        private readonly IGeneralService _generalService;
        private readonly IValidator<UpdateDriverCommand> _validator;

        public UpdateDriverCommandHandler(
            IDriverService driverService,
            IGeneralService generalService,
            IValidator<UpdateDriverCommand> validator)
        {
            _driverService = driverService;
            _generalService = generalService;
            _validator = validator;
        }

        public async override Task<UpdateDriverCommandResult> Handle(
            UpdateDriverCommand request,
            CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                var validationError = _generalService.ProcessValidationError(validationResult);
                return BadRequest(validationError);
            }

            _driverService.UpdateDriver(cancellationToken, request.Driver);

            return new UpdateDriverCommandResult();
        }
    }
}
