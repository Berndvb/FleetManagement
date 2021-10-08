using AutoMapper;
using FleetManagement.Domain.Interfaces.Repositories;
using FleetManagement.Framework.Models.Dtos.ShowDtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<List<AppealDto>> GetAllAppeals()
        {
            var appeals = await _unitOfWork.Appeals.GetListBy(
                filter: null,
                x => x.Include(y => y.Vehicle),
                x => x.Include(y => y.Driver));

            var appealDtos = _mapper.Map<List<AppealDto>>(appeals);

            return appealDtos;
        }
    }
}
