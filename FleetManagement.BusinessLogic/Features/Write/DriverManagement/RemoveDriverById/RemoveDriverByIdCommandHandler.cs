using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Services;
using FluentValidation;
using MediatR.Cqrs.Commands;

namespace FleetManagement.BLL.Features.Write.DriverManagement.RemoveDriverById
{
    public class RemoveDriverByIdCommandHandler : CommandHandler<RemoveDriverByIdCommand, RemoveDriverByIdCommandResult>
    {
        private readonly IDriverService _driverService;
        private readonly IGeneralService _generalService;
        private readonly IValidator<RemoveDriverByIdCommand> _validator;

        public RemoveDriverByIdCommandHandler(
            IDriverService driverService,
            IGeneralService generalService,
            IValidator<RemoveDriverByIdCommand> validator)
        {
            _driverService = driverService;
            _generalService = generalService;
            _validator = validator;
        }

        public async override Task<RemoveDriverByIdCommandResult> Handle(
            RemoveDriverByIdCommand request,
            CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                var validationError = _generalService.ProcessValidationError(validationResult);
                return BadRequest(validationError);
            }

            var driverIdError = await _driverService.CheckforIdError(cancellationToken, request.DriverId);
            if (driverIdError != null)
                return BadRequest(driverIdError);

            _driverService.RemoveDriver(cancellationToken, request.DriverId);

            return new RemoveDriverByIdCommandResult();
        }
    }
}
