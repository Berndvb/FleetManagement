using AutoMapper;
using FleetManagement.BLL.Services.Models;
using FleetManagement.Domain.Interfaces.Repositories;
using FleetManagement.Domain.Models;
using FleetManagement.Framework.Helpers;
using FleetManagement.Framework.Models.Dtos;
using FleetManagement.Framework.Models.Dtos.ShowDtos;
using MediatR.Cqrs.Execution;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Services
{
    public class DriverService : IDriverService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGeneralService _generalService;

        public DriverService(
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            IGeneralService generalService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _generalService = generalService;
        }

        public async Task<List<DriverOverviewDto>> GetDriverOverviews(bool onlyInService)
        {

            var drivers = onlyInService 
                ? await _unitOfWork.Drivers.GetListBy(including: x => x.Include(y => y.Identity)) 
                : await _unitOfWork.Drivers.GetListBy(filter: x => x.InService.Equals(true), including: x => x.Include(y => y.Identity));

            var driverOverviewDtos = _mapper.Map<List<DriverOverviewDto>>(drivers);

            return driverOverviewDtos;
        }

        public async Task<DriverDetailsDto> GetDriverDetails(string driverId)
        {
            var driver = await _unitOfWork.Drivers.GetBy(
                filter: x => x.Id.Equals(driverId.IdToInt()),
                x => x.Include(y => y.Identity),
                x => x.Include(y => y.Contactinfo),
                x => x.Include(y => y.Contactinfo.Address));

            var driverdetaillsDto = _mapper.Map<DriverDetailsDto>(driver);

            return driverdetaillsDto;
        }

        public async Task<List<FuelCardDto>> GetFuelCardsForDriver(string driverId)
        {
            var fuelCards = await _unitOfWork.FuelCards.GetListBy(
                filter: x => x.Drivers.Any(y => y.Driver.Id.Equals(driverId.IdToInt())),
                x => x.Include(y => y.FuelCardOptions));

            var fuelCardInfoDtos = _mapper.Map<List<FuelCardDto>>(fuelCards);

            return fuelCardInfoDtos;
        }

        public async Task<List<VehicleDetailsDto>> GetVehiclesForDriver(string driverId)
        {
            var driverVehicles = await _unitOfWork.DriverVehicles.GetListBy(
                filter: x => x.Driver.Id.Equals(driverId.IdToInt()),
                x => x.Include(y => y.Vehicle),
                x => x.Include(y => y.Vehicle.Identity));

            var vehicleDetailsDtos = _mapper.Map<List<VehicleDetailsDto>>(driverVehicles);

            return vehicleDetailsDtos;
        }

        public async Task<List<AppealDto>> GetAppealsForDriver(string driverId)
        {
            var appeals = await _unitOfWork.Appeals.GetListBy(
                filter: x => x.Driver.Id.Equals(driverId.IdToInt()),
                x => x.Include(y => y.Vehicle),
                x => x.Include(y => y.Vehicle.Identity));

            var appealDtos = _mapper.Map<List<AppealDto>>(appeals);

            return appealDtos;
        }

        public async Task<List<VehicleAppealDto>> GetAppealsForDriverPerCar(string driverId, string vehicleId)//for lazy loading @ GetVehicleDetailsForDriver
        {
            var vehicleAppeals = await _unitOfWork.Appeals.GetListBy(
                filter: x => x.Driver.Id.Equals(driverId.IdToInt()) && x.Vehicle.Id.Equals(vehicleId.IdToInt()));

            var vehicleAppealDtos = _mapper.Map<List<VehicleAppealDto>>(vehicleAppeals);

            return vehicleAppealDtos;
        }

        public async Task<List<VehicleMaintenanceDto>> GetMaintenancesForDriverPerCar(string driverId, string vehicleId)//for lazy loading @ GetVehicleDetailsForDriver
        {
            var maintenances = await _unitOfWork.Maintenance.GetListBy(
                filter: x => x.Driver.Id.Equals(driverId) && x.Vehicle.Id.Equals(vehicleId.IdToInt()));

            var maintenanceDtos = _mapper.Map<List<VehicleMaintenanceDto>>(maintenances);

            return maintenanceDtos;
        }

        public async Task<List<VehicleRepareDto>> GetRepairsForDriverPerCar(string driverId, string vehicleId)//for lazy loading @ GetVehicleDetailsForDriver
        {
            var reparations = await _unitOfWork.Repairs.GetListBy(
                filter: x => x.Driver.Id.Equals(driverId) && x.Vehicle.Id.Equals(vehicleId.IdToInt()));

            var reparationDtos = _mapper.Map<List<VehicleRepareDto>>(reparations);

            return reparationDtos;
        }

        public void UpdateDriver(DriverDetailsDto driverDto)
        {
            var driver = _mapper.Map<Driver>(driverDto);

            _unitOfWork.Drivers.Update(driver);

            _unitOfWork.Complete();
        }

        public void AddDriver(DriverDto driverDto)
        {
            var driver = _mapper.Map<Driver>(driverDto);

            _unitOfWork.Drivers.Insert(driver);

            _unitOfWork.Complete();
        }

        public void RemoveDriver(DriverDto driverDto)
        {
            var driver = _mapper.Map<Driver>(driverDto);

            _unitOfWork.Drivers.Remove(driver);

            _unitOfWork.Complete();
        }

        public void RemoveDriver(string driverId)
        {
            _unitOfWork.Drivers.RemoveById(driverId.IdToInt());

            _unitOfWork.Complete();
        }

        public async Task<IdValidationCodes> ValidateId(int id)
        {
            var ids = await _unitOfWork.Drivers.GetIds(id);

            return ids.Count switch
            {
                0 => IdValidationCodes.IdNotFound,
                > 1 => IdValidationCodes.IdNotUnique,
                _ => IdValidationCodes.OK,
            };
        }

        public async Task<ExecutionError> CheckforIdError(string driverId)
        {
            var idValidationCode = await ValidateId(driverId.IdToInt());
            if (idValidationCode != IdValidationCodes.OK)
                return _generalService.ProcessIdError(idValidationCode, nameof(driverId));

            return null;
        }
    }
}
