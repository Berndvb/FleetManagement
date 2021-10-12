using AutoMapper;
using FleetManagement.Domain.Interfaces.Repositories;
using FleetManagement.Domain.Models;
using FleetManagement.Framework.Models.Dtos.ReadDtos;
using FleetManagement.Framework.Models.Enums;
using FleetManagement.Framework.Paging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Services
{
    public class AppealService : IAppealService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppealService(
            IUnitOfWork unitOfWork, 
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

            return appealDtos;
        }
    }
}
