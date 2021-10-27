using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManagement.BLL.Services;
using FleetManagement.Framework.Constants;
using FleetManagement.Framework.Paging;
using FleetManager.EFCore.Infrastructure.Pagination;
using FleetManager.EFCore.UOW;
using MediatR.Cqrs.Execution;
using MediatR.Cqrs.Queries;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement.BLL.Features.DriverZone.GetFuelCardsForDriver
{
    public class GetFuelCardsForDriverQueryHandler : QueryHandler<GetFuelCardsForDriverQuery, GetFuelCardsForDriverQueryResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGeneralService _generalService;
        private readonly IDriverService _driverService;

        public GetFuelCardsForDriverQueryHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IGeneralService generalService,
            IDriverService driverService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _generalService = generalService;
            _driverService = driverService;
        }

        public async override Task<GetFuelCardsForDriverQueryResult> Handle(
            GetFuelCardsForDriverQuery request,
            CancellationToken cancellationToken)
        {
            var idError = await _driverService.ValidateId(request.DriverId, cancellationToken);
            if (idError != null)
                return BadRequest(idError);

            var fuelCardDtos = await GetFuelCardsForDriver(cancellationToken, request.DriverId, request.PagingParameters);
            if (fuelCardDtos.Count == 0)
            {
                var warning = new ExecutionWarning("We couldn't find and retrieve any fuelcard data.", Constants.WarningCodes.NoData);
                return SucceededWithNoData(warning);
            }

            var result = new GetFuelCardsForDriverQueryResult(fuelCardDtos);
            if (request.PagingParameters != null)
                result.FillPagingInfo((PaginatedList<FuelCardDto>)fuelCardDtos);

            return result;
        }

        private async Task<List<FuelCardDto>> GetFuelCardsForDriver(
           CancellationToken cancellationToken,
           int driverId,
           PagingParameters pagingParameter)
        {
            var fuelCards = await _unitOfWork.FuelCards.GetListBy(
                cancellationToken,
                pagingParameter,
                filter: x => x.FuelCardDrivers.Any(y => y.Driver.Id.Equals(driverId)),
                including: x => x
                    .Include(y => y.FuelCardOptions)
                    .Include(y => y.FuelCardDrivers.Where(z => z.Driver.Id.Equals(driverId))));

            var fuelCardDto = _mapper.Map<List<FuelCardDto>>(fuelCards);
            if (pagingParameter != null)
                return _generalService.GetPaginatedData(fuelCardDto, fuelCards);

            return fuelCardDto;
        }
    }
}
