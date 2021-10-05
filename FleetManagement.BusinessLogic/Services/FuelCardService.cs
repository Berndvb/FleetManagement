using AutoMapper;
using FleetManagement.Domain.Interfaces.Repositories;
using FleetManagement.Domain.Models;
using FleetManagement.Framework.Models.Dtos;

namespace FleetManagement.BLL.Services
{
    public class FuelCardService : IFuelCardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FuelCardService(
            IUnitOfWork unitOfWork, 
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void UpdateFuelCard(FuelCardDto fuelCardDto)
        {
            var fuelCard = _mapper.Map<FuelCard>(fuelCardDto);

            _unitOfWork.FuelCards.Update(fuelCard);

            _unitOfWork.Complete();
        }
    }
}
