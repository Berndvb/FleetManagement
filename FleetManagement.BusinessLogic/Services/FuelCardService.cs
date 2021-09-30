﻿using AutoMapper;
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

        public VehicleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<FuelCardDto>> GetFuelCardsDetailForDriver(int driverId)
        {
            var fuelCards = await _unitOfWork.FuelCards
                .Include(x => x.FuelCardOptions)
                .Include(x => x.Drivers)
                .Where(x => x.Drivers.Last().Id.Equals(driverId))
                .ToListAsync();
            var fuelCardInfoDtos = _mapper.Map<List<FuelCardDto>>(fuelCards);

            return fuelCardInfoDtos;
        }

        public void UpdateFuelCard(FuelCardDto fuelCardDto)
        {
            var fuelCard = _mapper.Map<FuelCard>(fuelCardDto);

            _unitOfWork.FuelCards.UpdateWithExclusion(fuelCard, x => x.Pincode, y => y.Drivers);

            _unitOfWork.Complete();
        }
    }
}