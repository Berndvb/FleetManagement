using AutoMapper;
using FleetManagement.BLL.Mapper.MapperSercice;
using FleetManagement.BLL.Services.Models;
using FleetManagement.Domain.Interfaces.Repositories;
using FleetManagement.Domain.Models;
using FleetManagement.Framework.Paging;
using MediatR.Cqrs.Execution;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManagement.BLL.Models.Dtos.WriteDtos;

namespace FleetManagement.BLL.Services
{
    public class DriverService : IDriverService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMapperService _mapperService;
        private readonly IGeneralService _generalService;

        public DriverService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMapperService mapperService,
            IGeneralService generalService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mapperService = mapperService;
            _generalService = generalService;
        }

        public async Task<List<DriverOverviewDto>> GetDriverOverviews(
            CancellationToken cancellationToken, 
            bool onlyInService, 
            PagingParameters pagingParameter)
        {
            var drivers = onlyInService
                ? await _unitOfWork.Drivers.GetListBy(
                    cancellationToken,
                    pagingParameter,
                    filter: x => x.InService,
                    including: x => x.Include(y => y.Identity))
                : await _unitOfWork.Drivers.GetListBy(
                    cancellationToken,
                    pagingParameter,
                    including: x => x.Include(y => y.Identity));

            var driverOverviewDtos = _mapper.Map<List<DriverOverviewDto>>(drivers);
            if (pagingParameter != null)
                return _mapperService.GetPaginatedData(driverOverviewDtos, drivers); 

            return driverOverviewDtos;
        }

        public async Task<DriverDetailsDto> GetDriverDetails(CancellationToken cancellationToken, int driverId)
        {
            var driver = await _unitOfWork.Drivers.GetBy(
                cancellationToken,
                filter: x => x.Id.Equals(driverId),
                including: x => x
                    .Include(y => y.Identity)
                    .Include(y => y.Contactinfo).ThenInclude(y => y.Address));

            var driverdetaillsDto = _mapper.Map<DriverDetailsDto>(driver);

            return driverdetaillsDto;
        }

        public async Task<List<FuelCardDto>> GetFuelCardsForDriver(
            CancellationToken cancellationToken,
            int driverId,
            PagingParameters pagingParameter)
        {
            var fuelCards = await _unitOfWork.FuelCards.GetListBy(
                cancellationToken,
                pagingParameter,
                filter: x => x.FuelCardDrivers.Any(y => y.Driver.Id.Equals(driverId)),
                including: x => x
                    .Include(y => y.FuelCardOptions)
                    .Include(y => y.FuelCardDrivers.Where(z => z.Driver.Id.Equals(driverId)))); 

            var fuelCardInfoDtos = _mapper.Map<List<FuelCardDto>>(fuelCards);
            if (pagingParameter != null)
                return _mapperService.GetPaginatedData(fuelCardInfoDtos, fuelCards);

            return fuelCardInfoDtos;
        }

        public async Task<List<VehicleDetailsDto>> GetVehicleInfoForDriver(
            CancellationToken cancellationToken, 
            int driverId, 
            PagingParameters pagingParameter)
        {
            var driverVehicles = await _unitOfWork.Vehicles.GetListBy(
                cancellationToken,
                pagingParameter,
                filter: x => x.Drivers.Any(y => y.Driver.Id.Equals(driverId)),
                including: x => x
                    .Include(y => y.Identity)
                    .Include(y => y.Drivers.Where(z => z.Driver.Id.Equals(driverId))));

            var vehicleDetailsDtos = _mapper.Map<List<VehicleDetailsDto>>(driverVehicles);
            if (pagingParameter != null)
                return _mapperService.GetPaginatedData(vehicleDetailsDtos, driverVehicles);

            return vehicleDetailsDtos;
        }

        public async Task<List<AppealDto>> GetAppealsForDriver(
            CancellationToken cancellationToken, 
            int driverId,
            PagingParameters pagingParameter)
        {
            var appeals = await _unitOfWork.Appeals.GetListBy(
                cancellationToken,
                pagingParameter,
                filter: x => x.Driver.Id.Equals(driverId),
                including: x => x.Include(y => y.Vehicle).ThenInclude(z => z.Identity));

            var appealDtos = _mapper.Map<List<AppealDto>>(appeals);
            if (pagingParameter != null)
                return _mapperService.GetPaginatedData(appealDtos, appeals);

            return appealDtos;
        }

        public async Task<List<AppealDto>> GetAppealsForDriverPerCar(
            CancellationToken cancellationToken,
            int driverId, 
            int vehicleId, 
            PagingParameters pagingParameter)
        {
            var vehicleAppeals = await _unitOfWork.Appeals.GetListBy(
                cancellationToken,
                pagingParameter,
                filter: x => x.Driver.Id.Equals(driverId) && x.Vehicle.Id.Equals(vehicleId));

            var vehicleAppealDtos = _mapper.Map<List<AppealDto>>(vehicleAppeals);
            if (pagingParameter != null)
                return _mapperService.GetPaginatedData(vehicleAppealDtos, vehicleAppeals);

            return vehicleAppealDtos;
        }

        public async Task<List<MaintenanceDto>> GetMaintenancesForDriverPerCar(
            CancellationToken cancellationToken,
            int driverId, 
            int vehicleId, 
            PagingParameters pagingParameter)
        {
            var maintenances = await _unitOfWork.Maintenance.GetListBy(
                cancellationToken,
                pagingParameter,
                filter: x => x.Driver.Id.Equals(driverId) && x.Vehicle.Id.Equals(vehicleId),
                including: x => x
                    .Include(y => y.Documents)
                    .Include(y => y.Garage));

            var maintenanceDtos = _mapper.Map<List<MaintenanceDto>>(maintenances);
            if (pagingParameter != null)
                return _mapperService.GetPaginatedData(maintenanceDtos, maintenances);

            return maintenanceDtos;
        }

        public async Task<List<RepareDto>> GetRepairsForDriverPerCar(
            CancellationToken cancellationToken,
            int driverId,
            int vehicleId, 
            PagingParameters pagingParameter)
        {
            var reparations = await _unitOfWork.Repairs.GetListBy(
                cancellationToken,
                pagingParameter,
                filter: x => x.Driver.Id.Equals(driverId) && x.Vehicle.Id.Equals(vehicleId),
                including: x => x
                    .Include(y => y.Documents)
                    .Include(y => y.Garage));

            var reparationDtos = _mapper.Map<List<RepareDto>>(reparations);
            if (pagingParameter != null)
                return _mapperService.GetPaginatedData(reparationDtos, reparations);

            return reparationDtos;
        }

        public async Task UpdateDriver(CancellationToken cancellationToken,DriverDetailsDto driverDto)
        {
            var driver = _mapper.Map<Driver>(driverDto);

            await _unitOfWork.Drivers.Update(cancellationToken, driver);

            _unitOfWork.Complete();
        }

        public async Task UpdateDriverById(CancellationToken cancellationToken, DriverDetailsDto driverDto, int driverId)
        {
            var driver = _mapper.Map<Driver>(driverDto);

            await _unitOfWork.Drivers.UpdateById(
                cancellationToken, 
                driverId, 
                driver, 
                including: x => x
                    .Include(y => y.Appeals)
                    .Include(y => y.FuelCards)
                    .Include(y => y.Vehicles));

            _unitOfWork.Complete();
        }

        public async Task AddDriver(CancellationToken cancellationToken, AddDriverDetailsDto driverDto)
        {
            var fuelCard = await _unitOfWork.FuelCards.GetBy(cancellationToken, filter: x => x.Id.Equals(driverDto.FuelCardId));
            var vehicle = await _unitOfWork.Vehicles.GetBy(cancellationToken, filter: x => x.Id.Equals(driverDto.VehicleId));
            var appeals = await _unitOfWork.Appeals.GetListBy(
                cancellationToken, 
                pagingParameters: null, 
                filter: x => x.Id.Equals(driverDto.AppealIds));

            var driver = _mapper.Map<Driver>(driverDto);
            var fuelCardDriver = new FuelCardDriver
            {
                Active = true,
                FuelCard = fuelCard,
                Driver = driver,
                CreationDate = DateTime.Now
            };
            var driverVehicle = new DriverVehicle
            {
                Active = true,
                Vehicle = vehicle,
                Driver = driver,
                CreationDate = DateTime.Now
            };

            driver.Appeals = appeals;
            driver.FuelCards = new List<FuelCardDriver>{ fuelCardDriver };
            driver.Vehicles = new List<DriverVehicle> { driverVehicle };

            await _unitOfWork.Drivers.Insert(cancellationToken, driver);

            _unitOfWork.Complete();
        }

        public void RemoveDriverById(CancellationToken cancellationToken,int driverId)
        {
            _unitOfWork.Drivers.RemoveById(cancellationToken, driverId);

            _unitOfWork.Complete();
        }

        public async Task<ExecutionError> ValidateId(CancellationToken cancellationToken, int id)
        {
            var ids = await _unitOfWork.Drivers.GetIds(cancellationToken, id);

            var validationCode =  ids.Count switch
            {
                0 => InputValidationCodes.IdNotFound,
                > 1 => InputValidationCodes.IdNotUnique,
                _ => InputValidationCodes.OK,
            };

            if (validationCode != InputValidationCodes.OK)
                return _generalService.ProcessValidationError(validationCode, nameof(id));

            return null;
        }
    }
}
