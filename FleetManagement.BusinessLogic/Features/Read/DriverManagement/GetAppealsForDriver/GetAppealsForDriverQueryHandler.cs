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

namespace FleetManagement.BLL.Features.Read.DriverManagement.GetAppeals
{
    public class GetAppealsForDriverQueryHandler : QueryHandler<GetAppealsForDriverQuery, GetAppealsForDriverQueryResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGeneralService _generalService;
        private readonly IDriverService _driverService;

        public GetAppealsForDriverQueryHandler(
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

        public async override Task<GetAppealsForDriverQueryResult> Handle(
            GetAppealsForDriverQuery request,
            CancellationToken cancellationToken)
        {
            var idError = await _driverService.ValidateId(cancellationToken, request.DriverId);
            if (idError != null)
                return BadRequest(idError);

            var driverAppeals = await GetAppealsForDriver(cancellationToken, request.DriverId, request.PagingParameters);
            if (driverAppeals.Count == 0)
            {
                var warning = new ExecutionWarning("We couldn't find and retrieve any driver-appeal data.", Constants.WarningCodes.NoData);
                return SucceededWithNoData(warning);
            }

            var result = new GetAppealsForDriverQueryResult(driverAppeals);
            if (request.PagingParameters != null)
                result.FillPagingInfo((PaginatedList<AppealDto>)driverAppeals);

            return result;
        }

        public async Task<List<AppealDto>> GetAppealsForDriver(
            CancellationToken cancellationToken,
            int driverId,
            PagingParameters pagingParameter)
        {
            var appeals = await _unitOfWork.Appeals.GetListBy(
                cancellationToken,
                pagingParameter,
                filter: x => x.Driver.Id.Equals(driverId),
                including: x => x
                    .Include(y => y.Vehicle)
                        .ThenInclude(z => z.Identity));

            var appealDtos = _mapper.Map<List<AppealDto>>(appeals);
            if (pagingParameter != null)
                return _generalService.GetPaginatedData(appealDtos, appeals);

            return appealDtos;
        }
    }
}
