using AutoMapper;
using FleetManagement.Domain.Interfaces.Repositories;

namespace FleetManagement.BLL.Services
{
    public class RepareService : IRepareService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RepareService(
            IUnitOfWork unitOfWork, 
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
