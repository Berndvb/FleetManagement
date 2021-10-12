using FleetManagement.BLL.Services;
using FluentValidation;
using MediatR.Cqrs.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.WriteAPI.Features.DriverManagement.AddDriver
{
    public class AddDriverCommandHandler : CommandHandler<AddDriverCommand, AddDriverCommandResult>
    {
        private readonly IDriverService _driverService;
        private readonly IGeneralService _generalService;
        private readonly IValidator<AddDriverCommand> _validator;

        public AddDriverCommandHandler(
            IDriverService driverService,
            IGeneralService generalService,
            IValidator<AddDriverCommand> validator)
        {
            _driverService = driverService;
            _generalService = generalService;
            _validator = validator;
        }

        public async override Task<AddDriverCommandResult> Handle(
            AddDriverCommand request,
            CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                var validationError = _generalService.ProcessValidationError(validationResult);
                return BadRequest(validationError);
            }

            _driverService.AddDriver(cancellationToken, request.Driver);

            return new AddDriverCommandResult();
        }
    }
}
