using AutoMapper;
using FleetManagement.BLL.Services.Models;
using FleetManagement.Domain.Interfaces.Repositories;
using FleetManagement.Domain.Models;
using FleetManagement.Framework.Helpers;
using FleetManagement.Framework.Models.Dtos.ReadDtos;
using FleetManagement.Framework.Models.Dtos.WriteDtos;
using FleetManagement.Framework.Paging;
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

        public async Task<List<DriverOverviewDto>> GetDriverOverviews(bool onlyInService, PagingParameters pagingParameter = null)
        {

            var drivers = onlyInService 
                ? await _unitOfWork.Drivers.GetListBy(filter: null, pagingParameter, including: x => x.Include(y => y.Identity)) 
                : await _unitOfWork.Drivers.GetListBy(filter: x => x.InService.Equals(true), pagingParameter, including: x => x.Include(y => y.Identity));

            var driverOverviewDtos = _mapper.Map<List<DriverOverviewDto>>(drivers);

            return driverOverviewDtos;
        }

        public async Task<DriverDetailsDto> GetDriverDetails(string driverId)
        {
            var driver = await _unitOfWork.Drivers.GetBy(
                filter: x => x.Id.Equals(driverId.StringToInt()),
                x => x.Include(y => y.Identity),
                x => x.Include(y => y.Contactinfo),
                x => x.Include(y => y.Contactinfo.Address));

            var driverdetaillsDto = _mapper.Map<DriverDetailsDto>(driver);

            return driverdetaillsDto;
        }

        public async Task<List<FuelCardDto>> GetFuelCardsForDriver(string driverId, PagingParameters pagingParameter = null)
        {
            var fuelCards = await _unitOfWork.FuelCards.GetListBy(
                filter: x => x.FuelCardDrivers.Any(y => y.Driver.Id.Equals(driverId.StringToInt())),
                pagingParameter,
                x => x.Include(y => y.FuelCardOptions),
                x => x.Include(y => y.FuelCardDrivers.Where(y => y.Driver.Id.Equals(driverId.StringToInt()))));

            var fuelCardInfoDtos = _mapper.Map<List<FuelCardDto>>(fuelCards);

            return fuelCardInfoDtos;
        }

        public async Task<List<VehicleDetailsDto>> GetVehicleInfoForDriver(string driverId, PagingParameters pagingParameter = null)
        {
            var driverVehicles = await _unitOfWork.Vehicles.GetListBy(
                filter: x => x.Drivers.Any(y => y.Driver.Id.Equals(driverId)),
                pagingParameter,
                x => x.Include(y => y.Identity),
                x => x.Include(y => y.Drivers.Where(z => z.Driver.Id.Equals(driverId))));

            var vehicleDetailsDtos = _mapper.Map<List<VehicleDetailsDto>>(driverVehicles);

            return vehicleDetailsDtos;
        }

        public async Task<List<AppealDto>> GetAppealsForDriver(string driverId, PagingParameters pagingParameter = null)
        {
            var appeals = await _unitOfWork.Appeals.GetListBy(
                filter: x => x.Driver.Id.Equals(driverId.StringToInt()),
                pagingParameter,
                x => x.Include(y => y.Vehicle),
                x => x.Include(y => y.Vehicle.Identity));

            var appealDtos = _mapper.Map<List<AppealDto>>(appeals);

            return appealDtos;
        }

        public async Task<List<AppealDto>> GetAppealsForDriverPerCar(string driverId, string vehicleId, PagingParameters pagingParameter = null)//for lazy loading @ GetVehicleDetailsForDriver
        {
            var vehicleAppeals = await _unitOfWork.Appeals.GetListBy(
                filter: x => x.Driver.Id.Equals(driverId.StringToInt()) && x.Vehicle.Id.Equals(vehicleId.StringToInt()),
                pagingParameter);

            var vehicleAppealDtos = _mapper.Map<List<AppealDto>>(vehicleAppeals);

            return vehicleAppealDtos;
        }

        public async Task<List<MaintenanceDto>> GetMaintenancesForDriverPerCar(string driverId, string vehicleId, PagingParameters pagingParameter = null)//for lazy loading @ GetVehicleDetailsForDriver
        {
            var maintenances = await _unitOfWork.Maintenance.GetListBy(
                filter: x => x.Driver.Id.Equals(driverId) && x.Vehicle.Id.Equals(vehicleId.StringToInt()),
                pagingParameter,
                x => x.Include(y => y.Documents),
                x => x.Include(y => y.Garage));

            var maintenanceDtos = _mapper.Map<List<MaintenanceDto>>(maintenances);

            return maintenanceDtos;
        }

        public async Task<List<RepareDto>> GetRepairsForDriverPerCar(string driverId, string vehicleId, PagingParameters pagingParameter = null)//for lazy loading @ GetVehicleDetailsForDriver
        {
            var reparations = await _unitOfWork.Repairs.GetListBy(
                filter: x => x.Driver.Id.Equals(driverId) && x.Vehicle.Id.Equals(vehicleId.StringToInt()),
                pagingParameter,
                x => x.Include(y => y.Documents),
                x => x.Include(y => y.Garage));

            var reparationDtos = _mapper.Map<List<RepareDto>>(reparations);

            return reparationDtos;
        }

        public void UpdateDriver(DriverDetailsDto driverDto)
        {
            var driver = _mapper.Map<Driver>(driverDto);

            _unitOfWork.Drivers.Update(driver);

            _unitOfWork.Complete();
        }

        public void AddDriver(AddDriverDto driverDto)
        {
            var driver = _mapper.Map<Driver>(driverDto);

            _unitOfWork.Drivers.Insert(driver);

            _unitOfWork.Complete();
        }

        public void RemoveDriver(DriverDetailsDto driverDto)
        {
            var driver = _mapper.Map<Driver>(driverDto);

            _unitOfWork.Drivers.Remove(driver);

            _unitOfWork.Complete();
        }

        public void RemoveDriver(string driverId)
        {
            _unitOfWork.Drivers.RemoveById(driverId.StringToInt());

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
            var idValidationCode = await ValidateId(driverId.StringToInt());
            if (idValidationCode != IdValidationCodes.OK)
                return _generalService.ProcessIdError(idValidationCode, nameof(driverId));

            return null;
        }
    }
}
