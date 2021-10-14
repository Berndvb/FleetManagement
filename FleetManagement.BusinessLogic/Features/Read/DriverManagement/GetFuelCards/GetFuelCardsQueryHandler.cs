using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManagement.BLL.Services;
using FleetManagement.Domain.Infrastructure.Pagination;
using FleetManagement.Framework.Constants;
using MediatR.Cqrs.Execution;
using MediatR.Cqrs.Queries;

namespace FleetManagement.BLL.Features.Read.DriverManagement.GetFuelCards
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
            var idError = await _driverService.ValidateId(cancellationToken, request.DriverId);
            if (idError != null)
                return BadRequest(idError);

            var fuelCardDtos = await _driverService.GetFuelCardsForDriver(cancellationToken, request.DriverId, request.PagingParameters);
            if (fuelCardDtos.Count == 0)
            {
                var warning = new ExecutionWarning("We couldn't find and retrieve any fuelcard data.", Constants.WarningCodes.NoData);
                return SucceededWithNoData(warning);
            }

            var result = new GetFuelCardsQueryResult(fuelCardDtos);
            if (request.PagingParameters != null)
                result.FillPagingInfo((PaginatedList<FuelCardDto>)fuelCardDtos);

            return result;
        }
    }
}
