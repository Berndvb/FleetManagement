using AutoMapper;
using FleetManagement.Domain.Interfaces.Repositories;
using FleetManagement.Domain.Models;
using FleetManagement.Framework.Models.Dtos.ReadDtos;
using FleetManagement.Framework.Paging;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<List<FuelCardDto>> GetAllFuelCards(PagingParameters pagingParameter = null)
        {
            var fuelCards = await _unitOfWork.FuelCards.GetListBy(
                pagingParameter,
                including: x => x.Include(y => y.FuelCardOptions).Include(y => y.FuelCardDrivers));

            var fuelCardDtos = _mapper.Map<List<FuelCardDto>>(fuelCards);

            return fuelCardDtos;
        } 
    }
}
