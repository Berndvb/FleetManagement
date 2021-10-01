using AutoMapper;
using FleetManagement.Domain.Interfaces;
using FleetManagement.Domain.Models;
using FleetManagement.Framework.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Services
{
    public class VehicleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VehicleService(
            IUnitOfWork unitOfWork, 
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<FuelCardDto>> GetFuelCardDetailsForDriver(int driverId)
        {
            var fuelCards = await _unitOfWork.FuelCards.GetListBy(
                filter: x => x.Drivers.Last().Id.Equals(driverId),
                x => x.Include(y => y.FuelCardOptions),
                x => x.Include(y => y.Drivers));

            var fuelCardInfoDtos = _mapper.Map<List<FuelCardDto>>(fuelCards);

            return fuelCardInfoDtos;
        }

        public void UpdateFuelCard(FuelCardDto fuelCardDto)
        {
            var fuelCard = _mapper.Map<FuelCard>(fuelCardDto);

            _unitOfWork.FuelCards.Update(fuelCard,
                x => x.Pincode,
                x => x.Drivers);

            _unitOfWork.Complete();
        }
    }
}
