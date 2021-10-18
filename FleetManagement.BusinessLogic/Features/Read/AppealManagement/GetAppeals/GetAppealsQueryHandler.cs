using AutoMapper;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManagement.BLL.Services;
using FleetManagement.Domain.Infrastructure.Pagination;
using FleetManagement.Domain.Interfaces.Repositories;
using FleetManagement.Domain.Models;
using FleetManagement.Framework.Constants;
using FleetManagement.Framework.Helpers;
using FleetManagement.Framework.Models.Enums;
using FleetManagement.Framework.Paging;
using MediatR.Cqrs.Execution;
using MediatR.Cqrs.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Features.Read.AppealManagement.GetAllAppeals
{
    public class GetAppealsQueryHandler : QueryHandler<GetAppealsQuery, GetAppealsQueryResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGeneralService _generalService;

        public GetAppealsQueryHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IGeneralService generalService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _generalService = generalService;
        }

        public async override Task<GetAppealsQueryResult> Handle(
            GetAppealsQuery request,
            CancellationToken cancellationToken)
        {
            var appeals = await GetAllAppeals(cancellationToken, request.PagingParameters, request.AppealStatus.StringToAppealStatus());
            if (appeals.Count == 0)
            {
                var warning = new ExecutionWarning("We couldn't find and retrieve any appeal data.", Constants.WarningCodes.NoData);
                return SucceededWithNoData(warning);
            }

            var result = new GetAppealsQueryResult(appeals);
            if (request.PagingParameters != null)
                result.FillPagingInfo((PaginatedList<AppealDto>)appeals);

            return result;
        }

        public async Task<List<AppealDto>> GetAllAppeals(
            CancellationToken cancellationToken, 
            PagingParameters pagingParameter = null, 
            AppealStatus appealstatus = 0)
        {
            Expression<Func<Appeal, bool>> getSpecificStatus = appealstatus == 0
                ? null
                : x => x.Status.Equals(appealstatus);

            var appeals = await _unitOfWork.Appeals.GetListBy(
                cancellationToken,
                pagingParameter,
                filter: getSpecificStatus,
                including: x => x
                    .Include(y => y.Vehicle)
                    .Include(y => y.Driver));

            var appealDtos = _mapper.Map<List<AppealDto>>(appeals);
            if (pagingParameter != null)
                return _generalService.GetPaginatedData(appealDtos, appeals);

            return appealDtos;
        }
    }
}
