using AutoMapper;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManagement.BLL.Services;
using FleetManagement.Domain.Infrastructure.Pagination;
using FleetManagement.Domain.Interfaces.Repositories;
using FleetManagement.Framework.Constants;
using FleetManagement.Framework.Paging;
using MediatR.Cqrs.Execution;
using MediatR.Cqrs.Queries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Features.Read.VehicleManagement.GetAllVehicles
{
    public class GetVehiclesQueryHandler : QueryHandler<GetVehiclesQuery, GetVehiclesQueryResult>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGeneralService _generalService;

        public GetVehiclesQueryHandler(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IGeneralService generalService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _generalService = generalService;
        }

        public async override Task<GetVehiclesQueryResult> Handle(
            GetVehiclesQuery request,
            CancellationToken cancellationToken)
        {
            var vehicles = await GetAllVehicles(cancellationToken, request.PagingParameters);
            if (vehicles.Count == 0)
            {
                var warning = new ExecutionWarning("We couldn't find and retrieve any vehicle data.", Constants.WarningCodes.NoData);
                return SucceededWithNoData(warning);
            }

            var result = new GetVehiclesQueryResult(vehicles);
            if (request.PagingParameters != null)
                result.FillPagingInfo((PaginatedList<VehicleDetailsDto>)vehicles);

            return result;
        }

        public async Task<List<VehicleDetailsDto>> GetAllVehicles(CancellationToken cancellationToken, PagingParameters pagingParameter)
        {
            var vehicles = await _unitOfWork.Vehicles.GetListBy(
                cancellationToken,
                pagingParameter,
                including: x => x
                 .Include(y => y.Identity)
                 .Include(y => y.Maintenances)
                 .Include(y => y.Reparations)
                 .Include(y => y.DriverVehicles)
                 .Include(y => y.Appeals));

            var vehicleDtos = _mapper.Map<List<VehicleDetailsDto>>(vehicles);
            if (pagingParameter != null)
                return _generalService.GetPaginatedData(vehicleDtos, vehicles);

            return vehicleDtos;
        }
    }
}
