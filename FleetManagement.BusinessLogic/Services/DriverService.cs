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

        public async Task<IEnumerable<DriverOverviewDto>> GetDriverOverviews(bool onlyInService) 
        {
            var firstDriverQuery = _unitOfWork.Drivers.Include(x => x.Identity.Name);
            var secondDriverQuery = onlyInService ? firstDriverQuery.Where(x => x.InService) : firstDriverQuery;
 
            var driverOverviewDtos = await secondDriverQuery
                .Select(x => _mapper.Map<DriverOverviewDto>(secondDriverQuery))
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

        public async Task<IEnumerable<VehicleDetailsDto>> GetVehicleDetailsForDriver(int driverId) 
        {
            var vehicles = await _unitOfWork.DriverVehicles
                .Include(x => x.Vehicle)
                .Include(x => x.Vehicle.Identity)
                .Where(x => x.Driver.Id.Equals(driverId))
                .ToListAsync();

            var vehicleDetailsDtos = new List<VehicleDetailsDto>();
            foreach (var vehicle in vehicles)
            {
                var vehicleIdentityDto = _mapper.Map<VehicleIdentityDto>(vehicles);
                var driverVehicleDto = _mapper.Map<DriverVehicleDto>(vehicles);
                var vehicleDetailsDto = new VehicleDetailsDto(vehicleIdentityDto, driverVehicleDto, vehicle.Vehicle.Mileage);
                vehicleDetailsDtos.Add(vehicleDetailsDto);
            }

            return vehicleDetailsDtos;
        }

        public async Task<IEnumerable<VehicleMaintenanceDto>> GetMaintenancesForDriverPerCar(int driverId, int vehicleId)// lazy loading @ GetVehicleDetailsForDriver
        {
            var maintenances = await _unitOfWork.Maintenance
                .GetAll()
                .Where(x => x.Driver.Id.Equals(driverId) && x.Vehicle.Id.Equals(vehicleId))
                .ToListAsync();

            var maintenanceDtos = new List<VehicleMaintenanceDto>();
            foreach (var maintenance in maintenances)
            {
                var maintenanceDto = _mapper.Map<VehicleMaintenanceDto>(maintenance);
                maintenanceDtos.Add(maintenanceDto);
            }

            return maintenanceDtos;
        }

        public async Task<List<VehicleReparationDto>> GetReparationsForDriverPerCar(int driverId)// lazy loading @ GetVehicleDetailsForDriver
        {

        }

        public async Task<List<VehicleAppealDto>> GetAppealsForDriverPerCar(int driverId)// lazy loading @ GetVehicleDetailsForDriver
        {
                            //.Include(x => x.Vehicles.Select(y => y.Vehicle.Appeals.Where(z => z.Driver.Id.Equals(driverId))))
        }

        public async Task<List<FuelCardDto>> GetFuelCardsDetailsForDriver(int driverId)
        {
            var fuelCards = await _unitOfWork.Drivers
                .Include(x => x.Fuelcards)
                .Include(x => x.Fuelcards.Select(y => y.FuelCard))
                .Include(x => x.Fuelcards.Select(y => y.FuelCard.FuelCardOptions))
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
    }
}
