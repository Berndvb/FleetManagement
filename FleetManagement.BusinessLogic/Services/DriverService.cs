using AutoMapper;
using FleetManagement.Domain.Interfaces;
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

        public async Task<List<DriverOverviewDto>> GetDriverOverviews(bool onlyInService) 
        {
            var firstDriverQuery = _unitOfWork.Drivers.Include(x => x.Identity.Name);
            var secondDriverQuery = onlyInService ? firstDriverQuery.Where(x => x.InService) : firstDriverQuery;
 
            var driverOverviewDtos = await secondDriverQuery
                .Select(x => _mapper.Map<DriverOverviewDto>(x))
                .ToListAsync();

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

        public async Task<List<VehicleInfoDto>> GetVehicleDetails(int driverId) 
        {
            var vehicles = await _unitOfWork.Drivers
                .Include(x => x.Vehicles) // theninclude
                .Include(x => x.Vehicles.Select(y => y.Vehicle))
                .Include(x => x.Vehicles.Select(y => y.Vehicle.Identity))
                .Include(x => x.Vehicles.Select(y => y.Vehicle.Maintenances.Where(z => z.Driver.Id.Equals(driverId))))
                .Include(x => x.Vehicles.Select(y => y.Vehicle.Reparations.Where(z => z.Driver.Id.Equals(driverId))))
                .Include(x => x.Vehicles.Select(y => y.Vehicle.Appeals.Where(z => z.Driver.Id.Equals(driverId))))
                .Where(x => x.Id.Equals(driverId))
                .ToListAsync();

            var vehicleDetailsDto = _mapper.Map<List<VehicleInfoDto>>(vehicles);

            return vehicleDetailsDto;
        }

        public async Task<List<FuelCardInfoDto>> GetFuelCardsDetails(int driverId)
        {
            var fuelCards = await _unitOfWork.Drivers
                .Include(x => x.Fuelcards)
                .Include(x => x.Fuelcards.Select(y => y.FuelCard))
                .Include(x => x.Fuelcards.Select(y => y.FuelCard.FuelCardOptions))
                .Where(x => x.Id.Equals(driverId))
                .ToListAsync();

            var fuelCardInfoDtos = _mapper.Map<List<FuelCardInfoDto>>(fuelCards);

            return fuelCardInfoDtos;
        }

        public async Task<List<AppealInfoDto>> GetAppealInfo(int driverId)
        {
            var appeals = await _unitOfWork.Drivers
                .Include(x => x.Appeals)
                .Include(x => x.Appeals.Select(y => y.Vehicle))
                .Include(x => x.Appeals.Select(y => y.Vehicle.Identity))
                .Where(x => x.Id.Equals(driverId))
                .ToListAsync();

            var appealInfoDtos = _mapper.Map<List<AppealInfoDto>>(appeals);

            return appealInfoDtos;

        }
    }
}
