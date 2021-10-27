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
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Features.DriverZone.GetVehiclesForDriver
{
    public class GetVehiclesForDriverQueryHandler : QueryHandler<GetVehiclesForDriverQuery, GetVehiclesForDriverQueryResult>
    {
        private readonly IDriverService _driverService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGeneralService _generalService;

        public GetVehiclesForDriverQueryHandler(
            IDriverService driverService,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IGeneralService generalService)
        {
            _driverService = driverService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _generalService = generalService;
        }

        public async override Task<GetVehiclesForDriverQueryResult> Handle(
            GetVehiclesForDriverQuery request,
            CancellationToken cancellationToken)
        {
            var driverIdError = await _driverService.ValidateId(request.DriverId, cancellationToken);
            if (driverIdError != null)
                return BadRequest(driverIdError);

            var vehicles = await GetVehiclesForDriver(cancellationToken, request.DriverId, request.PagingParameters);
            if (vehicles.Count == 0)
            {
                var warning = new ExecutionWarning("We couldn't find and retrieve any vehicle data.", Constants.WarningCodes.NoData);
                return SucceededWithNoData(warning);
            }

            var result = new GetVehiclesForDriverQueryResult(vehicles);
            if (request.PagingParameters != null)
                result.FillPagingInfo((PaginatedList<VehicleDetailsDto>)vehicles);

            return result;
        }

        private async Task<List<VehicleDetailsDto>> GetVehiclesForDriver(
            CancellationToken cancellationToken,
            int driverId,
            PagingParameters pagingParameter)
        {
            var driverVehicles = await _unitOfWork.Vehicles.GetListBy(
                cancellationToken,
                pagingParameter,
                filter: x => x.DriverVehicles.Any(y => y.Driver.Id.Equals(driverId)),
                including: x => x
                    .Include(y => y.Identity)
                    .Include(y => y.Maintenances)
                        .ThenInclude(z => z.Garage)
                    .Include(y => y.Maintenances)
                        .ThenInclude(z => z.Driver.Identity)
                    .Include(y => y.Reparations)
                        .ThenInclude(z => z.Garage)
                    .Include(y => y.Reparations)
                        .ThenInclude(z => z.Driver.Identity)
                    .Include(y => y.Appeals)
                        .ThenInclude(z => z.Driver.Identity)
                    .Include(y => y.DriverVehicles.Where(z => z.Driver.Id.Equals(driverId))));

            var vehicleDetailsDtos = _mapper.Map<List<VehicleDetailsDto>>(driverVehicles);

            if (pagingParameter != null)
                return _generalService.GetPaginatedData(vehicleDetailsDtos, driverVehicles);

            return vehicleDetailsDtos;
        }
    }
}
