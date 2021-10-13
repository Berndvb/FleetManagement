using AutoMapper;
using FleetManagement.BLL.Mapper.MapperSercice;
using FleetManagement.Domain.Interfaces.Repositories;
using FleetManagement.Domain.Models;
using FleetManagement.Framework.Models.Enums;
using FleetManagement.Framework.Paging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Models.Dtos.ReadDtos;

namespace FleetManagement.BLL.Services
{
    public class AppealService : IAppealService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMapperService _mapperService;

        public AppealService(
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            IMapperService mapperService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mapperService = mapperService;
        }

        public async Task<List<AppealDto>> GetAllAppeals(CancellationToken cancellationToken, PagingParameters pagingParameter = null, AppealStatus appealstatus = 0)
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
                return _mapperService.GetPaginatedData(appealDtos, appeals);

            return appealDtos;
        }
    }
}
