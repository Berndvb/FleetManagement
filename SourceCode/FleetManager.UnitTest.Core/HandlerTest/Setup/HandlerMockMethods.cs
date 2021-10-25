using AutoMapper;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManagement.BLL.Services;
using FleetManagement.Domain.Models;
using FleetManagement.Framework.Paging;
using FleetManager.EFCore.Repositories;
using FleetManager.EFCore.UOW;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;

namespace FleetManager.UnitTest.Core.HandlerTest.Setup
{
    public class QueryHandlerFactory
    {
        private protected int driverId = 1;
        private protected const int fuelCardId = 1;
        private protected const int appealId = 1;
        private protected readonly CancellationToken _cancellationToken = CancellationToken.None;
        private protected readonly Mock<IUnitOfWork> _unitOfWork;
        private protected readonly Mock<IMapper> _mapper;
        private protected readonly Mock<IGenericRepository<Driver>> _driverRepo;
        private protected readonly Mock<IGenericRepository<Appeal>> _appealRepo;
        private protected readonly Mock<IGenericRepository<FuelCard>> _fuelCardRepo;
        private protected readonly Mock<IGenericRepository<Vehicle>> _vehicleRepo;
        private protected readonly Mock<IDriverService> _driverService;
        private protected readonly Mock<IGeneralService> _generalService;
        public PagingParameters PagingParameters { get; set; }
        private protected Driver Driver { get; set; }
        public DriverDetailsDto DriverDetailsDto { get; set; }


        public QueryHandlerFactory()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _mapper = new Mock<IMapper>();
            _driverRepo = new Mock<IGenericRepository<Driver>>();
            _appealRepo = new Mock<IGenericRepository<Appeal>>();
            _fuelCardRepo = new Mock<IGenericRepository<FuelCard>>();
            _vehicleRepo = new Mock<IGenericRepository<Vehicle>>();
            _driverService = new Mock<IDriverService>();
            _generalService = new Mock<IGeneralService>();
            PagingParameters = new PagingParameters {PageNumber = 1, PageSize = 5};
            Driver = new Driver { Id = driverId, InService = true };
            DriverDetailsDto = new DriverDetailsDto { Id = driverId, InService = true };
        }

        public IGeneralService WithGeneralService() => _generalService.Object;

        public IDriverService WithDriverService() => _driverService.Object;

        public IUnitOfWork WithUnitOfWorkForDriver()
        {
            _driverRepo
                .Setup(x => x.GetBy(
                    It.Is<CancellationToken>(y => y.Equals(_cancellationToken)),
                    It.IsAny<Expression<Func<Driver, bool>>>(),
                    It.IsAny<Func<IQueryable<Driver>, IIncludableQueryable<Driver, object>>>()))
                .ReturnsAsync(Driver);
            _unitOfWork
                .Setup(x => x.Drivers)
                .Returns(_driverRepo.Object);

            return _unitOfWork.Object;
        }

        public IMapper WithMapperForDriver()
        {
            _mapper
                .Setup(x => x.Map<DriverDetailsDto>(It.IsAny<Driver>()))
                .Returns((DriverDetailsDto)null);

            return _mapper.Object;
        }

        public IMapper WithMapperForDriverDetails()
        {
            _mapper
                .Setup(x => x.Map<DriverDetailsDto>(It.IsAny<Driver>()))
                .Returns(DriverDetailsDto);

            return _mapper.Object;
        }
    }
}
