using FleetManagement.BLL.Services;
using MediatR.Cqrs.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.WriteAPI.Features.DriverManagement.RemoveDriver
{
    public class RemoveDriverByIdCommandHandler : CommandHandler<RemoveDriverByIdCommand, RemoveDriverByIdCommandResult>
    {
        private readonly IDriverService _driverService;

        public RemoveDriverByIdCommandHandler(
            IDriverService driverService)
        {
            _driverService = driverService;
        }

        public async override Task<RemoveDriverByIdCommandResult> Handle(
            RemoveDriverByIdCommand request,
            CancellationToken cancellationToken)
        {
            _driverService.RemoveDriver(int.Parse(request.DriverId));

            return new RemoveDriverByIdCommandResult();
        }
    }
}
