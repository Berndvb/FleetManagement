using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Services;
using FluentValidation;
using MediatR.Cqrs.Commands;

namespace FleetManagement.BLL.Features.Write.DriverManagement.UpdateDriver
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
            _driverService.UpdateDriver(cancellationToken, request.Driver);

            return new UpdateDriverCommandResult();
        }
    }
}
