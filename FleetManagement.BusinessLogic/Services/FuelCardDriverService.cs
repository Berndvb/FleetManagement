using AutoMapper;
using FleetManagement.Domain.Interfaces.Repositories;
using FleetManagement.Domain.Models;
using FleetManagement.Framework.Models.Dtos.ReadDtos;
using FleetManagement.Framework.Models.WriteDtos;
using System.Threading;

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

        public void UpdateFuelCardDriver(CancellationToken cancellationToken, FuelCardDriverDto fuelCardDriverDto)
        {
            var fuelCardDriver = _mapper.Map<FuelCardDriver>(fuelCardDriverDto);

            _unitOfWork.FuelCardDrivers.Update(cancellationToken, fuelCardDriver);

            _unitOfWork.Complete();
        }

        public void AddFuelCardDriver(CancellationToken cancellationToken, AddFuelCardDriverDto fuelCardDriverDto)
        {
            var fuelCardDriver = _mapper.Map<FuelCardDriver>(fuelCardDriverDto);

            _unitOfWork.FuelCardDrivers.Insert(cancellationToken, fuelCardDriver);

            _unitOfWork.Complete();
        }

    }
}
