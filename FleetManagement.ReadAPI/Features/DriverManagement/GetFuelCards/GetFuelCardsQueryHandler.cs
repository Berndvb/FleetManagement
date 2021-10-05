using FleetManagement.BLL.Services;
using MediatR.Cqrs.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetFuelCardDetails
{
    public class GetFuelCardsQueryHandler : QueryHandler<GetFuelCardsQuery, GetFuelCardsQueryResult>
    {
        private readonly IDriverService _driverService;

        public GetFuelCardsQueryHandler(IDriverService driverService)
        {
            _driverService = driverService;
        }

        public async override Task<GetFuelCardsQueryResult> Handle(
            GetFuelCardsQuery request,
            CancellationToken cancellationToken)
        {
            var fuelCardDtos = await _driverService.GetFuelCardsForDriver(int.Parse(request.DriverId));

            return new GetFuelCardsQueryResult(fuelCardDtos);
        }
    }
}
