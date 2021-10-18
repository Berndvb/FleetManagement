﻿using AutoMapper;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
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

namespace FleetManagement.BLL.Features.Read.DriverManagement.GetAllDriverOverviews
{
    public class GetDriverOverviewsQueryHandler : QueryHandler<GetDriverOverviewsQuery, GetDriverOverviewsQueryResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDriverOverviewsQueryHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async override Task<GetDriverOverviewsQueryResult> Handle(
            GetDriverOverviewsQuery request,
            CancellationToken cancellationToken)
        {
            var driverOverviews = await GetDriverOverviews(cancellationToken, onlyInService: request.OnlyInService, request.PagingParameters);
            if (driverOverviews.Count == 0)
            {
                var warning = new ExecutionWarning("We couldn't find and retrieve any driver-overview data.", Constants.WarningCodes.NoData);
                return SucceededWithNoData(warning);
            }

            var result = new GetDriverOverviewsQueryResult(driverOverviews);
            if (request.PagingParameters != null)
                result.FillPagingInfo((PaginatedList<DriverOverviewDto>)driverOverviews);

            return result;
        }


        public async Task<List<DriverOverviewDto>> GetDriverOverviews(
            CancellationToken cancellationToken,
            bool onlyInService,
            PagingParameters pagingParameter)
        {
            var drivers = onlyInService
                ? await _unitOfWork.Drivers.GetListBy(
                    cancellationToken,
                    pagingParameter,
                    filter: x => x.InService,
                    including: x => x.Include(y => y.Identity))
                : await _unitOfWork.Drivers.GetListBy(
                    cancellationToken,
                    pagingParameter,
                    including: x => x.Include(y => y.Identity));

            var driverOverviewDtos = _mapper.Map<List<DriverOverviewDto>>(drivers);
            //if (pagingParameter != null)
            //    return _mapperService.GetPaginatedData(driverOverviewDtos, drivers);

            return driverOverviewDtos;
        }
    }
}
