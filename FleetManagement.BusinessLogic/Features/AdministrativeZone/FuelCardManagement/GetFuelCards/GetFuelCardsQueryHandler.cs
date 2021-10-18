using System.Collections.Generic;
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

namespace FleetManagement.BLL.Features.AdministrativeZone.FuelCardManagement.GetFuelCards
{
    public class GetFuelCardsQueryHandler : QueryHandler<GetFuelCardsQuery, GetFuelCardsQueryResult>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGeneralService _generalService;

        public GetFuelCardsQueryHandler(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IGeneralService generalService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _generalService = generalService;
        }

        public async override Task<GetFuelCardsQueryResult> Handle(
            GetFuelCardsQuery request,
            CancellationToken cancellationToken) 
        {
            var fuelCards = await GetAllFuelCards(cancellationToken, request.PagingParameters);
            if (fuelCards.Count == 0)
            {
                var warning = new ExecutionWarning("We couldn't find and retrieve any fuelcard data.", Constants.WarningCodes.NoData);
                return SucceededWithNoData(warning);
            }

            var result = new GetFuelCardsQueryResult(fuelCards);
            if (request.PagingParameters != null)
                result.FillPagingInfo((PaginatedList<FuelCardDto>)fuelCards);

            return result;
        }

        public async Task<List<FuelCardDto>> GetAllFuelCards(CancellationToken cancellationToken, PagingParameters pagingParameter = null)
        {
            var fuelCards = await _unitOfWork.FuelCards.GetListBy(
                cancellationToken,
                pagingParameter,
                including: x => x
                    .Include(y => y.FuelCardOptions)
                    .Include(y => y.FuelCardDrivers));

            var fuelCardDtos = _mapper.Map<List<FuelCardDto>>(fuelCards);
            if (pagingParameter != null)
                return _generalService.GetPaginatedData(fuelCardDtos, fuelCards);

            return fuelCardDtos;
        }
    }
}
