using FleetManagement.BLL.Services;
using MediatR.Cqrs.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Features.Write.DriverManagement.UpdateDriver
{
    public class UpdateDriverCommandHandler : CommandHandler<UpdateDriverCommand, UpdateDriverCommandResult>
    {
        private readonly IDriverService _driverService;

        public UpdateDriverCommandHandler(
            IDriverService driverService)
        {
            _driverService = driverService;
        }

        public async override Task<UpdateDriverCommandResult> Handle(
            UpdateDriverCommand request,
            CancellationToken cancellationToken)
        {
            await _driverService.UpdateDriver(cancellationToken, request.Driver);

            return new UpdateDriverCommandResult();
        }
    }
}
