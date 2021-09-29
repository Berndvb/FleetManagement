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
    public class DriverService 
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DriverService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DriverOverviewDto>> GetAllDriverOverviews(bool onlyInService) 
        {
            var driverQuery = _unitOfWork.Drivers
                .Include(x => x.Identity.Name);

            var drivers = onlyInService ? 
                await driverQuery.Where(x => x.InService).ToListAsync() : 
                await driverQuery.ToListAsync();

            var driverOverviewDtos = _mapper.Map<List<DriverOverviewDto>>(drivers);

            //var driverOverviewDtos = new List<DriverOverviewDto>();
            //await secondDriverQuery.ForEachAsync(driver => driverOverviewDtos.Add(_mapper.Map<DriverOverviewDto>(driver)));

            return driverOverviewDtos;
        }

        public async Task<DriverDetailsDto> GetDriverDetails(int driverId) 
        {
            var driver = await _unitOfWork.Drivers
                .Include(x => x.Identity)
                .Include(x => x.Contactinfo)
                .Include(x => x.Contactinfo.Address)
                .SingleAsync(x => x.Id == driverId);

            var driverdetaillsDto = _mapper.Map<DriverDetailsDto>(driver); 

            return driverdetaillsDto;
        }

        public async Task<List<FuelCardDto>> GetFuelCardsDetailsForDriver(int driverId)
        {
            var fuelCards = await _unitOfWork.Drivers
                .Include(x => x.FuelCards)
                .Include(x => x.FuelCards.Select(y => y.FuelCard))
                .Include(x => x.FuelCards.Select(y => y.FuelCard.FuelCardOptions))
                .Where(x => x.Id.Equals(driverId))
                .ToListAsync();

            var fuelCardInfoDtos = _mapper.Map<List<FuelCardDto>>(fuelCards);

            return fuelCardInfoDtos;
        }

        public async Task<List<AppealDto>> GetAppealInfoForDriver(int driverId)
        {
            var appeals = await _unitOfWork.Drivers
                .Include(x => x.Appeals)
                .Include(x => x.Appeals.Select(y => y.Vehicle))
                .Include(x => x.Appeals.Select(y => y.Vehicle.Identity))
                .Where(x => x.Id.Equals(driverId))
                .ToListAsync();

            var appealInfoDtos = _mapper.Map<List<AppealDto>>(appeals);

            return appealInfoDtos;
        }

        public async Task<IEnumerable<VehicleAppealDto>> GetAppealsForDriverPerCar(int driverId, int vehicleId)//for lazy loading @ GetVehicleDetailsForDriver
        {
            var appeals = await _unitOfWork.Drivers
                .Include(x => x.Appeals.Where(y => y.Vehicle.Id.Equals(vehicleId)))
                .Where(x => x.Id.Equals(driverId))
                .ToListAsync();

            var vehicleAppealDtos = _mapper.Map<List<VehicleAppealDto>>(appeals);

            return vehicleAppealDtos;
        }
    }
}
