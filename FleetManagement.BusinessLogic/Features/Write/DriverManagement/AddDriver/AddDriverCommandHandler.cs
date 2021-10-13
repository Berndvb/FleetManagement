using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Services;
using MediatR.Cqrs.Commands;

namespace FleetManagement.BLL.Features.Write.DriverManagement.AddDriver
{
    public class AddDriverCommandHandler : CommandHandler<AddDriverCommand, AddDriverCommandResult>
    {
        private readonly IDriverService _driverService;

        public AddDriverCommandHandler(
            IDriverService driverService)
        {
            _driverService = driverService;
        }

        public async override Task<AddDriverCommandResult> Handle(
            AddDriverCommand request,
            CancellationToken cancellationToken)
        {
            await _driverService.AddDriver(cancellationToken, request.DriverId);

            return new AddDriverCommandResult();
        }
    }
}
