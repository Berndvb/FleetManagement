using FleetManagement.BLL.Services;
using MediatR.Cqrs.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.WriteAPI.Features.FuelCardManagement.UpdateFuelCardDriver
{
    public class UpdateFuelCardDriverCommandHandler : CommandHandler<UpdateFuelCardDriverCommand, UpdateFuelCardDriverCommandResult>
    {
        private readonly IFuelCardDriverService _fuelCardDriverService;

        public UpdateFuelCardDriverCommandHandler(
            IFuelCardDriverService fuelCardDriverService)
        {
            _fuelCardDriverService = fuelCardDriverService;
        }

        public async override Task<UpdateFuelCardDriverCommandResult> Handle(
             UpdateFuelCardDriverCommand request,
            CancellationToken cancellationToken)
        {
            _fuelCardDriverService.UpdateFuelCardDriver(request.FuelCardDriver);

            return new UpdateFuelCardDriverCommandResult();
        }
    }
}
