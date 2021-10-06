using FleetManagement.BLL.Services;
using MediatR.Cqrs.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.WriteAPI.Features.DriverManagement.RemoveDriver
{
    public class RemoveDriverCommandHandler : CommandHandler<RemoveDriverCommand, RemoveDriverCommandResult>
    {
        private readonly IDriverService _driverService;

        public RemoveDriverCommandHandler(
            IDriverService driverService)
        {
            _driverService = driverService;
        }

        public async override Task<RemoveDriverCommandResult> Handle(
            RemoveDriverCommand request,
            CancellationToken cancellationToken)
        {
            _driverService.RemoveDriver(request.Driver);

            return new RemoveDriverCommandResult();
        }
    }
}
