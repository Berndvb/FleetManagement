using AutoMapper;
using FleetManagement.Domain.Interfaces;

namespace FleetManagement.BLL.Services.DI
{
    public class VehicleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VehicleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
