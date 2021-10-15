using AutoMapper;
using FleetManagement.BLL.Mapper.MapperSercice;
using FleetManagement.Domain.Interfaces.Repositories;
using FleetManagement.Domain.Models;
using FleetManagement.Framework.Paging;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManagement.BLL.Models.Dtos.WriteDtos;

namespace FleetManagement.BLL.Services
{
    public class FuelCardService : IFuelCardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMapperService _mapperService;

        public FuelCardService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMapperService mapperService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mapperService = mapperService;
        }

        public async Task UpdateFuelCard(CancellationToken cancellationToken, FuelCardDto fuelCardDto, int fuelCardId)
        {
            var fuelCard = _mapper.Map<FuelCard>(fuelCardDto);

            await Task.Run(() => _unitOfWork.FuelCards.Update(cancellationToken, fuelCard, fuelCardId));

            _unitOfWork.Complete();
        }

        public async Task<List<FuelCardDto>> GetAllFuelCards(CancellationToken cancellationToken, PagingParameters pagingParameter = null)
        {
            var fuelCards = await _unitOfWork.FuelCards.GetListBy(
                cancellationToken,
                pagingParameter,
                including: x => x
                    .Include(y => y.FuelCardOptions)
                    .Include(y => y.FuelCardDrivers));

            var fuelCardDtos = _mapper.Map<List<FuelCardDto>>(fuelCards);
            if (pagingParameter != null)
                return _mapperService.GetPaginatedData(fuelCardDtos, fuelCards);

            return fuelCardDtos;
        }

        public async Task AddFuelCard(CancellationToken cancellationToken, AddFuelCardDto fuelCardDto)
        {
            var fuelCard = _mapper.Map<FuelCard>(fuelCardDto);
    
            await _unitOfWork.FuelCards.Insert(cancellationToken, fuelCard);

            _unitOfWork.Complete();
        }
    }
}
