using AutoMapper;
using FleetManagement.Domain.Interfaces;
using FleetManagement.Framework.Models.Dtos;
using FleetManagement.Framework.Models.Dtos.ShowDtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Services
{
    public class AppealService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppealService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<AppealDto>> GetAppealInfoForDriver(int driverId, int vehicleId)
        {
            var appeals = await _unitOfWork.Appeals
                .Include(x => x.Vehicle)
                .Include(x => x.Vehicle.Identity)
                .Where(x => x.Driver.Id.Equals(driverId) && x.Vehicle.Id.Equals(vehicleId))
                .ToListAsync();

            var appealDtos = _mapper.Map<List<AppealDto>>(appeals);

            return appealDtos;
        }
    }
}
