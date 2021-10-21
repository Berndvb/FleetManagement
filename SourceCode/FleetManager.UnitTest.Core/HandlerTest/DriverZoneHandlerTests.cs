using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FleetManagement.BLL.Features.DriverZone.AddAppeal;
using FleetManagement.BLL.Features.DriverZone.GetAppealsForDriver;
using FleetManagement.BLL.Features.DriverZone.GetDriverDetails;
using FleetManagement.BLL.Features.DriverZone.GetFuelCardsForDriver;
using FleetManagement.BLL.Features.DriverZone.GetVehiclesForDriver;
using FleetManagement.BLL.Features.DriverZone.UpdateAppeal;
using FleetManagement.BLL.Features.DriverZone.UpdateContactInfo;
using FleetManagement.BLL.Features.DriverZone.UpdateFuelCard;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManagement.BLL.Services;
using FleetManagement.Domain.Models;
using FleetManagement.Framework.Models.Enums;
using FleetManagement.Framework.Paging;
using FleetManager.EFCore.Infrastructure.Pagination;
using FleetManager.EFCore.Repositories;
using FleetManager.EFCore.UOW;
using FluentAssertions;
using MediatR.Cqrs.Execution;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using Xunit;
using FuelCard = FleetManagement.Domain.Models.FuelCard;

namespace FleetManager.UnitTest.Core.HandlerTest
{
    /// <summary>
    /// Can the handler:
    /// - send parameters to the UnitOfWork?
    /// - receive the result from the UnitOfWork?
    /// - convert the UnitOfWork-result to the propper ExecutionResult?
    /// </summary>
    /// <returns></returns>
    public class DriverZoneHandlerTests
    {
        private int driverId = 1;
        private const int fuelCardId = 1;
        private const int appealId = 1;
        private  readonly CancellationToken _cancellationToken = CancellationToken.None;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IGenericRepository<Driver>> _driverRepo;
        private readonly Mock<IGenericRepository<Appeal>> _appealRepo;
        private readonly Mock<IGenericRepository<FuelCard>> _fuelCardRepo;
        private readonly Mock<IGenericRepository<Vehicle>> _vehicleRepo;
        private readonly Mock<IDriverService> _driverService;
        private readonly Mock<IGeneralService> _generalService;

        public DriverZoneHandlerTests()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _mapper = new Mock<IMapper>();
            _driverRepo = new Mock<IGenericRepository<Driver>>();
            _appealRepo = new Mock<IGenericRepository<Appeal>>();
            _fuelCardRepo = new Mock<IGenericRepository<FuelCard>>();
            _vehicleRepo = new Mock<IGenericRepository<Vehicle>>();
            _driverService = new Mock<IDriverService>();
            _generalService = new Mock<IGeneralService>();
        }

        [Fact]
        public async Task Should_not_get_driver_details()
        {
            //Arrange
            var handler = new GetDriverDetailsQueryHandler(_unitOfWork.Object, _mapper.Object);
            var query = new GetDriverDetailsQuery();
            var driver = new Driver();

            _driverRepo
                .Setup(x => x.GetBy(
                        It.Is<CancellationToken>(y => y.Equals(_cancellationToken)),
                        It.IsAny<Expression<Func<Driver, bool>>>(),
                    It.IsAny<Func<IQueryable<Driver>, IIncludableQueryable<Driver, object>>>()))
                .ReturnsAsync(driver);
            _unitOfWork
                .Setup(x => x.Drivers)
                .Returns(_driverRepo.Object);
            _mapper
                .Setup(x => x.Map<DriverDetailsDto>(It.IsAny<Driver>()))
                .Returns((DriverDetailsDto)null);

            //Act
            var result = await handler.Handle(query, _cancellationToken);

            //Assert
            result.Should().BeOfType(typeof(GetDriverDetailsQueryResult));
            result.HasSucceeded.Should().BeFalse();
            result.HasPaging.Should().BeFalse();
            result.HasWarnings.Should().BeFalse();
            result.ErrorType.Should().Be(ExecutionErrorType.BadRequest);
            result.GetErrors().Should().NotBeEmpty();
            var resultParsed = result as GetDriverDetailsQueryResult;
            resultParsed.DriverDetails.Should().BeNull();
        }

        [Fact]
        public async Task Should_get_driver_details()
        {
            //Arrange
            var handler = new GetDriverDetailsQueryHandler(_unitOfWork.Object, _mapper.Object);
            var query = new GetDriverDetailsQuery();
            var driver = new Driver{Id = driverId, InService = true};
            var driverDetailsDto = new DriverDetailsDto{Id = driverId, InService = true};

            _driverRepo
                .Setup(x => x.GetBy(
                    It.Is<CancellationToken>(y => y.Equals(_cancellationToken)),
                    It.IsAny<Expression<Func<Driver, bool>>>(),
                    It.IsAny<Func<IQueryable<Driver>, IIncludableQueryable<Driver, object>>>()))
                .ReturnsAsync(driver);
            _unitOfWork
                .Setup(x => x.Drivers)
                .Returns(_driverRepo.Object);
            _mapper
                .Setup(x => x.Map<DriverDetailsDto>(It.IsAny<Driver>()))
                .Returns(driverDetailsDto);

            //Act
            var result = await handler.Handle(query, _cancellationToken);

            //Assert
            result.Should().BeOfType(typeof(GetDriverDetailsQueryResult));
            result.HasSucceeded.Should().BeTrue();
            result.HasPaging.Should().BeFalse();
            result.HasWarnings.Should().BeFalse();
            result.GetErrors().Should().BeEmpty();
            var resultParsed = result as GetDriverDetailsQueryResult;
            resultParsed.DriverDetails.Id.Should().Be(1);
        }

        [Fact]
        public async Task Should_not_get_appeals_for_driver()
        {
            //Arrange
            var handler = new GetAppealsForDriverQueryHandler(_unitOfWork.Object, _mapper.Object, _generalService.Object, _driverService.Object);
            var query = new GetAppealsForDriverQuery();
            var appeals = new List<Appeal>();
            var appealDtos = new List<AppealDto>();

            _appealRepo
                .Setup(x => x.GetListBy(
                    It.Is<CancellationToken>(y => y.Equals(_cancellationToken)),
                    It.IsAny<PagingParameters>(),
                    It.IsAny<Expression<Func<Appeal, bool>>>(),
                    It.IsAny<Func<IQueryable<Appeal>, IIncludableQueryable<Appeal, object>>>()))
                .ReturnsAsync(appeals);
            _unitOfWork
                .Setup(x => x.Appeals)
                .Returns(_appealRepo.Object);
            _mapper
                .Setup(x => x.Map<List<AppealDto>>(It.IsAny<List<Appeal>>()))
                .Returns(appealDtos);

            //Act
            var result = await handler.Handle(query, _cancellationToken);

            //Assert
            result.Should().BeOfType(typeof(GetAppealsForDriverQueryResult));
            result.HasSucceeded.Should().BeTrue();
            result.HasPaging.Should().BeFalse();
            result.HasWarnings.Should().BeTrue();
            result.WarningType.Should().Be(ExecutionWarningType.NoData);
            result.GetErrors().Should().BeEmpty();
            var resultParsed = result as GetAppealsForDriverQueryResult;
            resultParsed.Appeals.Should().BeNull();
        }

        [Fact]
        public async Task Should_get_appeals_for_driver()
        {
            //Arrange
            var handler = new GetAppealsForDriverQueryHandler(_unitOfWork.Object, _mapper.Object, _generalService.Object, _driverService.Object);
            var pagingParameters = new PagingParameters{PageSize = 5, PageNumber = 1};
            var query = new GetAppealsForDriverQuery { DriverId = driverId, PagingParameters = pagingParameters};
            var appeals = new List<Appeal>();
            var appealDtos = new List<AppealDto>{new AppealDto()};
            var paginationResult = new PaginatedList<AppealDto>(appealDtos, 1, 1, 5);

            _appealRepo
                .Setup(x => x.GetListBy(
                    It.Is<CancellationToken>(y => y.Equals(_cancellationToken)),
                    It.Is<PagingParameters>(y => y.PageSize.Equals(pagingParameters.PageSize)),
                    It.IsAny<Expression<Func<Appeal, bool>>>(),
                    It.IsAny<Func<IQueryable<Appeal>, IIncludableQueryable<Appeal, object>>>()))
                .ReturnsAsync(appeals);
            _unitOfWork
                .Setup(x => x.Appeals)
                .Returns(_appealRepo.Object);
            _mapper
                .Setup(x => x.Map<List<AppealDto>>(It.IsAny<List<Appeal>>()))
                .Returns(appealDtos);
            _generalService
                .Setup(x => x.GetPaginatedData(appealDtos, appeals))
                .Returns(paginationResult);

            //Act
            var result = await handler.Handle(query, _cancellationToken);

            //Assert
            result.Should().BeOfType(typeof(GetAppealsForDriverQueryResult));
            result.HasSucceeded.Should().BeTrue();
            result.HasPaging.Should().BeTrue();
            result.HasWarnings.Should().BeFalse();
            result.GetErrors().Should().BeEmpty();
            var resultParsed = result as GetAppealsForDriverQueryResult;
            resultParsed.ExecutionPaging.PageSize.Equals(5);
            resultParsed.Appeals.Count.Should().Be(1);
        }

        [Fact]
        public async Task Should_not_get_fuelCards_for_driver()
        {
            //Arrange
            var handler = new GetFuelCardsForDriverQueryHandler(_unitOfWork.Object, _mapper.Object, _generalService.Object, _driverService.Object);
            var query = new GetFuelCardsForDriverQuery();
            var fuelCards = new List<FuelCard>();
            var fuelCardDtos = new List<FuelCardDto>();

            _fuelCardRepo
                .Setup(x => x.GetListBy(
                    It.Is<CancellationToken>(y => y.Equals(_cancellationToken)),
                    It.IsAny<PagingParameters>(),
                    It.IsAny<Expression<Func<FuelCard, bool>>>(),
                    It.IsAny<Func<IQueryable<FuelCard>, IIncludableQueryable<FuelCard, object>>>()))
                .ReturnsAsync(fuelCards);
            _unitOfWork
                .Setup(x => x.FuelCards)
                .Returns(_fuelCardRepo.Object);
            _mapper
                .Setup(x => x.Map<List<FuelCardDto>>(It.IsAny<List<FuelCard>>()))
                .Returns(fuelCardDtos);

            //Act
            var result = await handler.Handle(query, _cancellationToken);

            //Assert
            result.Should().BeOfType(typeof(GetFuelCardsForDriverQueryResult));
            result.HasSucceeded.Should().BeTrue();
            result.HasPaging.Should().BeFalse();
            result.HasWarnings.Should().BeTrue();
            result.WarningType.Should().Be(ExecutionWarningType.NoData);
            result.GetErrors().Should().BeEmpty();
            var resultParsed = result as GetFuelCardsForDriverQueryResult;
            resultParsed.FuelCards.Should().BeNull();
        }

        [Fact]
        public async Task Should_get_fuelCards_for_driver()
        {
            //Arrange
            var handler = new GetFuelCardsForDriverQueryHandler(_unitOfWork.Object, _mapper.Object, _generalService.Object, _driverService.Object);
            var pagingParameters = new PagingParameters { PageSize = 5, PageNumber = 1 };
            var query = new GetFuelCardsForDriverQuery() { DriverId = driverId, PagingParameters = pagingParameters };
            var fuelCards = new List<FuelCard>();
            var fuelCardDtos = new List<FuelCardDto> { new FuelCardDto() };
            var paginationResult = new PaginatedList<FuelCardDto>(fuelCardDtos, 1, 1, 5);

            _fuelCardRepo
                .Setup(x => x.GetListBy(
                    It.Is<CancellationToken>(y => y.Equals(_cancellationToken)),
                    It.Is<PagingParameters>(y => y.PageSize.Equals(pagingParameters.PageSize)),
                    It.IsAny<Expression<Func<FuelCard, bool>>>(),
                    It.IsAny<Func<IQueryable<FuelCard>, IIncludableQueryable<FuelCard, object>>>()))
                .ReturnsAsync(fuelCards);
            _unitOfWork
                .Setup(x => x.FuelCards)
                .Returns(_fuelCardRepo.Object);
            _mapper
                .Setup(x => x.Map<List<FuelCardDto>>(It.IsAny<List<FuelCard>>()))
                .Returns(fuelCardDtos);
            _generalService
                .Setup(x => x.GetPaginatedData(fuelCardDtos, fuelCards))
                .Returns(paginationResult);

            //Act
            var result = await handler.Handle(query, _cancellationToken);

            //Assert
            result.Should().BeOfType(typeof(GetFuelCardsForDriverQueryResult));
            result.HasSucceeded.Should().BeTrue();
            result.HasPaging.Should().BeTrue();
            result.HasWarnings.Should().BeFalse();
            result.GetErrors().Should().BeEmpty();
            var resultParsed = result as GetFuelCardsForDriverQueryResult;
            resultParsed.ExecutionPaging.PageSize.Equals(5);
            resultParsed.FuelCards.Count.Should().Be(1);
        }

        [Fact]
        public async Task Should_not_get_vehicles_for_driver()
        {
            //Arrange
            var handler = new GetVehiclesForDriverQueryHandler(_driverService.Object, _unitOfWork.Object, _mapper.Object, _generalService.Object);
            var query = new GetVehiclesForDriverQuery();
            var vehicles = new List<Vehicle>();
            var vehicleDetailsDtos = new List<VehicleDetailsDto>();

            _vehicleRepo
                .Setup(x => x.GetListBy(
                    It.Is<CancellationToken>(y => y.Equals(_cancellationToken)),
                    It.IsAny<PagingParameters>(),
                    It.IsAny<Expression<Func<Vehicle, bool>>>(),
                    It.IsAny<Func<IQueryable<Vehicle>, IIncludableQueryable<Vehicle, object>>>()))
                .ReturnsAsync(vehicles);
            _unitOfWork
                .Setup(x => x.Vehicles)
                .Returns(_vehicleRepo.Object);
            _mapper
                .Setup(x => x.Map<List<VehicleDetailsDto>>(It.IsAny<List<Vehicle>>()))
                .Returns(vehicleDetailsDtos);

            //Act
            var result = await handler.Handle(query, _cancellationToken);

            //Assert
            result.Should().BeOfType(typeof(GetVehiclesForDriverQueryResult));
            result.HasSucceeded.Should().BeTrue();
            result.HasPaging.Should().BeFalse();
            result.HasWarnings.Should().BeTrue();
            result.WarningType.Should().Be(ExecutionWarningType.NoData);
            result.GetErrors().Should().BeEmpty();
            var resultParsed = result as GetVehiclesForDriverQueryResult;
            resultParsed.VehicleDetails.Should().BeNull();
        }

        [Fact]
        public async Task Should_get_vehicles_for_driver()
        {
            //Arrange
            var handler = new GetVehiclesForDriverQueryHandler(_driverService.Object, _unitOfWork.Object, _mapper.Object, _generalService.Object);
            var pagingParameters = new PagingParameters { PageSize = 5, PageNumber = 1 };
            var query = new GetVehiclesForDriverQuery() { DriverId = driverId, PagingParameters = pagingParameters };
            var vehicles = new List<Vehicle>();
            var vehicleDetailsDtos = new List<VehicleDetailsDto> { new VehicleDetailsDto() };
            var paginationResult = new PaginatedList<VehicleDetailsDto>(vehicleDetailsDtos, 1, 1, 5);

            _vehicleRepo
                .Setup(x => x.GetListBy(
                    It.Is<CancellationToken>(y => y.Equals(_cancellationToken)),
                    It.Is<PagingParameters>(y => y.PageSize.Equals(pagingParameters.PageSize)),
                    It.IsAny<Expression<Func<Vehicle, bool>>>(),
                    It.IsAny<Func<IQueryable<Vehicle>, IIncludableQueryable<Vehicle, object>>>()))
                .ReturnsAsync(vehicles);
            _unitOfWork
                .Setup(x => x.Vehicles)
                .Returns(_vehicleRepo.Object);
            _mapper
                .Setup(x => x.Map<List<VehicleDetailsDto>>(It.IsAny<List<Vehicle>>()))
                .Returns(vehicleDetailsDtos);
            _generalService
                .Setup(x => x.GetPaginatedData(vehicleDetailsDtos, vehicles))
                .Returns(paginationResult);

            //Act
            var result = await handler.Handle(query, _cancellationToken);

            //Assert
            result.Should().BeOfType(typeof(GetVehiclesForDriverQueryResult));
            result.HasSucceeded.Should().BeTrue();
            result.HasPaging.Should().BeTrue();
            result.HasWarnings.Should().BeFalse();
            result.GetErrors().Should().BeEmpty();
            var resultParsed = result as GetVehiclesForDriverQueryResult;
            resultParsed.ExecutionPaging.PageSize.Equals(5);
            resultParsed.VehicleDetails.Count.Should().Be(1);
        }

        [Fact]
        public async Task Should_add_appeal_for_driver()
        {
            //Arrange
            var handler = new AddAppealCommandHandler(_unitOfWork.Object);
            var driverIdentity = new IdentityPerson{FirstName = "TestFirstName", Name = "TestName"};
            var driver = new Driver{ Identity = driverIdentity};
            var command = new AddAppealCommand();

            _vehicleRepo
                .Setup(x => x.GetBy(
                    It.Is<CancellationToken>(y => y.Equals(_cancellationToken)),
                    It.IsAny<Expression<Func<Vehicle, bool>>>(),
                    It.IsAny<Func<IQueryable<Vehicle>, IIncludableQueryable<Vehicle, object>>>()))
                .ReturnsAsync((Vehicle)null);
            _driverRepo
                .Setup(x => x.GetBy(
                    It.Is<CancellationToken>(y => y.Equals(_cancellationToken)),
                    It.IsAny<Expression<Func<Driver, bool>>>(),
                    It.IsAny<Func<IQueryable<Driver>, IIncludableQueryable<Driver, object>>>()))
                .ReturnsAsync(driver);
            _appealRepo
                .Setup(x => x.Insert(
                It.Is<Appeal>(y => y.Driver.Id.Equals(driverId)),
                It.Is<CancellationToken>(y => y.Equals(_cancellationToken))));
            _unitOfWork
                .Setup(x => x.Vehicles)
                .Returns(_vehicleRepo.Object);
            _unitOfWork
                .Setup(x => x.Drivers)
                .Returns(_driverRepo.Object);
            _unitOfWork
                .Setup(x => x.Appeals)
                .Returns(_appealRepo.Object);

            //Act
            var result = await handler.Handle(command, _cancellationToken);

            //Assert
            result.Should().BeOfType(typeof(AddAppealCommandResult));
            result.HasSucceeded.Should().BeTrue();
            result.HasPaging.Should().BeFalse();
            result.HasWarnings.Should().BeFalse();
            result.GetErrors().Should().BeEmpty();
        }

        [Fact]
        public async Task Should_update_appealInfo_for_driver()
        {
            //Arrange
            var handler = new UpdateAppealInfoCommandHandler(_unitOfWork.Object);
            var command = new UpdateAppealInfoCommand();
            var appeal = new Appeal(
                new DateTime(2021,10,10), 
                AppealType.FuelCard, AppealStatus.New,
                new Vehicle(), 
                new Driver{Id = driverId},
                message: "Test");


            _appealRepo
                .Setup(x => x.GetBy(
                    It.Is<CancellationToken>(y => y.Equals(_cancellationToken)),
                    It.IsAny<Expression<Func<Appeal, bool>>>(),
                    It.IsAny<Func<IQueryable<Appeal>, IIncludableQueryable<Appeal, object>>>()))
                .ReturnsAsync(appeal);
            _appealRepo
                .Setup(x => x.Update(
                It.Is<Appeal>(y => y.Driver.Id.Equals(appealId)),
                It.Is<CancellationToken>(y => y.Equals(_cancellationToken))));
            _unitOfWork
                .Setup(x => x.Appeals)
                .Returns(_appealRepo.Object);

            //Act
            var result = await handler.Handle(command, _cancellationToken);

            //Assert
            result.Should().BeOfType(typeof(UpdateAppealInfoCommandResult));
            result.HasSucceeded.Should().BeTrue();
            result.HasPaging.Should().BeFalse();
            result.HasWarnings.Should().BeFalse();
            result.GetErrors().Should().BeEmpty();
        }

        [Fact]
        public async Task Should_update_ContactInfo_for_driver()
        {
            //Arrange
            var handler = new UpdateContactInfoCommandHandler(_unitOfWork.Object);
            var command = new UpdateContactInfoCommand();
            var address = new Address{Street = "test", StreetNumber = "test", City = "test", Postcode = "test"};
            var contactInfo = new ContactInfo{EmailAddress = "test", PhoneNumber = "test", Address = address};
            var driver = new Driver{ Contactinfo = contactInfo };

            _driverRepo
                .Setup(x => x.GetBy(
                    It.Is<CancellationToken>(y => y.Equals(_cancellationToken)),
                    It.IsAny<Expression<Func<Driver, bool>>>(),
                    It.IsAny<Func<IQueryable<Driver>, IIncludableQueryable<Driver, object>>>()))
                .ReturnsAsync(driver);
            _driverRepo
                .Setup(x => x.Update(
                    It.Is<Driver>(y => y.Id.Equals(driverId)),
                    It.Is<CancellationToken>(y => y.Equals(_cancellationToken))));
            _unitOfWork
                .Setup(x => x.Drivers)
                .Returns(_driverRepo.Object);

            //Act
            var result = await handler.Handle(command, _cancellationToken);

            //Assert
            result.Should().BeOfType(typeof(UpdateContactInfoCommandResult));
            result.HasSucceeded.Should().BeTrue();
            result.HasPaging.Should().BeFalse();
            result.HasWarnings.Should().BeFalse();
            result.GetErrors().Should().BeEmpty();
        }

        [Fact]
        public async Task Should_update_fuelCardInfo_for_driver()
        {
            //Arrange
            var handler = new UpdateFuelCardInfoCommandHandler(_unitOfWork.Object);
            var command = new UpdateFuelCardInfoCommand();
            var fuelCard = new FuelCard{AuthenticationType = AuthenticationType.Pin};

            _fuelCardRepo
                .Setup(x => x.GetBy(
                    It.Is<CancellationToken>(y => y.Equals(_cancellationToken)),
                    It.IsAny<Expression<Func<FuelCard, bool>>>(),
                    It.IsAny<Func<IQueryable<FuelCard>, IIncludableQueryable<FuelCard, object>>>()))
                .ReturnsAsync(fuelCard);
            _fuelCardRepo
                .Setup(x => x.Update(
                    It.Is<FuelCard>(y => y.Id.Equals(fuelCardId)),
                    It.Is<CancellationToken>(y => y.Equals(_cancellationToken))));
            _unitOfWork
                .Setup(x => x.FuelCards)
                .Returns(_fuelCardRepo.Object);

            //Act
            var result = await handler.Handle(command, _cancellationToken);

            //Assert
            result.Should().BeOfType(typeof(UpdateFuelCardInfoCommandResult));
            result.HasSucceeded.Should().BeTrue();
            result.HasPaging.Should().BeFalse();
            result.HasWarnings.Should().BeFalse();
            result.GetErrors().Should().BeEmpty();
        }
    }
}
