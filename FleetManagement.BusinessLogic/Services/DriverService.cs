using AutoMapper;
using FleetManagement.Domain.Interfaces;
using FleetManagement.Domain.Models;
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

        public DriverService(
            IUnitOfWork unitOfWork, 
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<DriverOverviewDto>> GetAllDriverOverviews(bool onlyInService)
        {

            var drivers = onlyInService 
                ? await _unitOfWork.Drivers.GetListBy(including: x => x.Include(y => y.Identity)) 
                : await _unitOfWork.Drivers.GetListBy(filter: x => x.InService.Equals(true), including: x => x.Include(y => y.Identity));

            var driverOverviewDtos = _mapper.Map<List<DriverOverviewDto>>(drivers);

            return driverOverviewDtos;
        }

        public async Task<DriverDetailsDto> GetDriverDetails(int driverId)
        {
            var driver = await _unitOfWork.Drivers.GetBy(
                filter: x => x.Id.Equals(driverId),
                x => x.Include(y => y.Identity),
                x => x.Include(y => y.Contactinfo),
                x => x.Include(y => y.Contactinfo.Address));

            var driverdetaillsDto = _mapper.Map<DriverDetailsDto>(driver);

            return driverdetaillsDto;
        }

        public async Task<List<FuelCardDto>> GetFuelCardDetailsForDriver(int driverId)//!!Too hard to map? - alternative in FuelCardService
        {
            var driversWithFuelCards = await _unitOfWork.Drivers.GetListBy(
                filter: x => x.Id.Equals(driverId),
                x => x.Include(y => y.FuelCards),
                x => x.Include(y => y.FuelCards.Select(z => z.FuelCard)),
                x => x.Include(y => y.FuelCards.Select(z => z.FuelCard.FuelCardOptions)));

            var fuelCardInfoDtos = _mapper.Map<List<FuelCardDto>>(driversWithFuelCards);

            return fuelCardInfoDtos;
        }

        public async Task<List<AppealDto>> GetAllAppealsForDriver(int driverId)
        {
            var appeals = await _unitOfWork.Drivers.GetListBy(
                filter: x => x.Id.Equals(driverId),
                x => x.Include(y => y.Appeals),
                x => x.Include(y => y.Appeals.Select(z => z.Vehicle)),
                x => x.Include(y => y.Appeals.Select(z => z.Vehicle.Identity)));

            var appealInfoDtos = _mapper.Map<List<AppealDto>>(appeals);

            return appealInfoDtos;
        }

        public async Task<List<VehicleAppealDto>> GetAppealsForDriverPerCar(int driverId, int vehicleId)//for lazy loading @ GetVehicleDetailsForDriver
        {
            var driverWithAppeals = await _unitOfWork.Drivers.GetListBy(
                filter: x => x.Id.Equals(driverId),
                x => x.Include(y => y.Appeals.Where(z => z.Vehicle.Id.Equals(vehicleId))));

            var vehicleAppealDtos = _mapper.Map<List<VehicleAppealDto>>(driverWithAppeals);

            return vehicleAppealDtos;
        }

        public void UpdateDriver(DriverDetailsDto driverDto)
        {
            var driver = _mapper.Map<Driver>(driverDto);

            _unitOfWork.Drivers.Update(driver,
                x => x.Appeals,
                x => x.Vehicles,
                x => x.FuelCards);

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

        public void RemoveDriver(int driverId)
        {
            _unitOfWork.Drivers.RemoveById(driverId);

            _unitOfWork.Complete();
        }
    }
}
