using AutoMapper;
using FleetManagement.Domain.Interfaces.Repositories;
using FleetManagement.Domain.Models;
using FleetManagement.Framework.Models.Dtos.ReadDtos;
using FleetManagement.Framework.Models.WriteDtos;

namespace FleetManagement.BLL.Services
{
    public class FuelCardDriverService : IFuelCardDriverService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FuelCardDriverService(
            IUnitOfWork unitOfWork, 
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void UpdateFuelCardDriver(FuelCardDriverDto fuelCardDriverDto)
        {
            var fuelCardDriver = _mapper.Map<FuelCardDriver>(fuelCardDriverDto);

            _unitOfWork.FuelCardDrivers.Update(fuelCardDriver);

            _unitOfWork.Complete();
        }

        public void AddFuelCardDriver(AddFuelCardDriverDto fuelCardDriverDto)
        {
            var fuelCardDriver = _mapper.Map<FuelCardDriver>(fuelCardDriverDto);

            _unitOfWork.FuelCardDrivers.Insert(fuelCardDriver);

            _unitOfWork.Complete();
        }

    }
}
