using FleetManagement.BLL.Services;
using MediatR.Cqrs.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.WriteAPI.Features.DriverManagement.AddDriver
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
            _driverService.AddDriver(request.Driver);

            return new AddDriverCommandResult();
        }
    }
}
