using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Features.DriverZone.GetAppealsForDriver;
using FleetManagement.BLL.Features.DriverZone.GetDriverDetails;
using FleetManagement.BLL.Features.DriverZone.GetFuelCardsForDriver;
using FleetManagement.BLL.Features.DriverZone.GetVehiclesForDriver;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManagement.Framework.Constants;
using FleetManagement.ReadAPI.Controllers;
using FluentAssertions;
using MediatR;
using MediatR.Cqrs.Execution;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace FleetManager.UnitTest.Core.ControllerTest
{
    /// <summary>
    /// Can the controller:
    /// - send parameters to the mediatR?
    /// - receive the result from the mediatR?
    /// - convert the mediatR-result to IActionresult?
    /// </summary>
    /// <returns></returns>
    public class ReadAPIDriverZoneControllerTests
    {
        private const int driverId = 1;
        private readonly CancellationToken _cancellationToken = CancellationToken.None;
        private readonly Mock<IMediator> _mediator;
        private readonly DriverZoneController _controller;

        public ReadAPIDriverZoneControllerTests()
        {
            _mediator = new Mock<IMediator>();
            _controller = new DriverZoneController(_mediator.Object);
        }

        [Fact]
        public async Task Should_not_get_driver_details()
        {
            //Arrange
            var query = new GetDriverDetailsQuery {DriverId = driverId};
            var queryError = new ExecutionError("Id-Error", Constants.ErrorCodes.IdNotUnique);
            var queryRespons = ExecutionResult.BadRequest(queryError).As<GetDriverDetailsQueryResult>();

            _mediator.Setup(x => x.Send(
                It.Is<GetDriverDetailsQuery>(y => y.DriverId == driverId),
                It.Is<CancellationToken>(z => z.Equals(_cancellationToken))))
                .ReturnsAsync(queryRespons);

            //Act
            var result = await _controller.GetDriverDetails(query, _cancellationToken);

            //Assert
            result.Should().BeOfType(typeof(BadRequestObjectResult));
            var objectResult = result as BadRequestObjectResult;
            objectResult.Value.Should().NotBeNull();
            objectResult.Value.Should().BeOfType(typeof(ExecutionResultDto));
        }

        [Fact]
        public async Task Should_get_driver_details()
        {
            //Arrange
            var query = new GetDriverDetailsQuery { DriverId = driverId };
            var queryRespons = new GetDriverDetailsQueryResult(new DriverDetailsDto());

            _mediator.Setup(x => x.Send(
                    It.Is<GetDriverDetailsQuery>(y => y.DriverId == driverId),
                    It.Is<CancellationToken>(z => z.Equals(_cancellationToken))))
                .ReturnsAsync(queryRespons);

            //Act
            var result = await _controller.GetDriverDetails(query, _cancellationToken);

            //Assert
            result.Should().BeOfType(typeof(OkObjectResult));
            var objectResult = result as OkObjectResult;
            objectResult.Value.Should().NotBeNull();
            objectResult.Value.Should().BeOfType(typeof(GetDriverDetailsQueryResult));
        }

        [Fact]
        public async Task Should_not_get_driver_fuelCards()
        {
            //Arrange
            var query = new GetFuelCardsForDriverQuery() { DriverId = driverId };
            var queryError = new ExecutionError("Id-Error", Constants.ErrorCodes.IdNotUnique);
            var queryRespons = ExecutionResult.BadRequest(queryError).As<GetFuelCardsForDriverQueryResult>();

            _mediator.Setup(x => x.Send(
                    It.Is<GetFuelCardsForDriverQuery>(y => y.DriverId == driverId),
                    It.Is<CancellationToken>(z => z.Equals(_cancellationToken))))
                .ReturnsAsync(queryRespons);

            //Act
            var result = await _controller.GetFuelCardsForDriver(query, _cancellationToken);

            //Assert
            result.Should().BeOfType(typeof(BadRequestObjectResult));
            var objectResult = result as BadRequestObjectResult;
            objectResult.Value.Should().NotBeNull();
            objectResult.Value.Should().BeOfType(typeof(ExecutionResultDto));
        }


        [Fact]
        public async Task Should_get_driver_fuelCards()
        {
            //Arrange
            var query = new GetFuelCardsForDriverQuery() { DriverId = driverId };
            var queryRespons = new GetFuelCardsForDriverQueryResult(new List<FuelCardDto>());

            _mediator.Setup(x => x.Send(
                    It.Is<GetFuelCardsForDriverQuery>(y => y.DriverId == driverId),
                    It.Is<CancellationToken>(z => z.Equals(_cancellationToken))))
                .ReturnsAsync(queryRespons);

            //Act
            var result = await _controller.GetFuelCardsForDriver(query, _cancellationToken);

            //Assert
            result.Should().BeOfType(typeof(OkObjectResult));
            var objectResult = result as OkObjectResult;
            objectResult.Value.Should().NotBeNull();
            objectResult.Value.Should().BeOfType(typeof(GetFuelCardsForDriverQueryResult));
        }

        [Fact]
        public async Task Should_not_get_driver_appeals()
        {
            //Arrange
            var query = new GetAppealsForDriverQuery() { DriverId = driverId };
            var queryError = new ExecutionError("Id-Error", Constants.ErrorCodes.IdNotUnique);
            var queryRespons = ExecutionResult.BadRequest(queryError).As<GetAppealsForDriverQueryResult>();

            _mediator.Setup(x => x.Send(
                    It.Is<GetAppealsForDriverQuery>(y => y.DriverId == driverId),
                    It.Is<CancellationToken>(z => z.Equals(_cancellationToken))))
                .ReturnsAsync(queryRespons);

            //Act
            var result = await _controller.GetAppealsForDriver(query, _cancellationToken);

            //Assert
            result.Should().BeOfType(typeof(BadRequestObjectResult));
            var objectResult = result as BadRequestObjectResult;
            objectResult.Value.Should().NotBeNull();
            objectResult.Value.Should().BeOfType(typeof(ExecutionResultDto));
        }

        [Fact]
        public async Task Should_get_driver_appeals()
        {
            //Arrange
            var query = new GetFuelCardsForDriverQuery() { DriverId = driverId };
            var queryRespons = new GetFuelCardsForDriverQueryResult(new List<FuelCardDto>());

            _mediator.Setup(x => x.Send(
                    It.Is<GetFuelCardsForDriverQuery>(y => y.DriverId == driverId),
                    It.Is<CancellationToken>(z => z.Equals(_cancellationToken))))
                .ReturnsAsync(queryRespons);

            //Act
            var result = await _controller.GetFuelCardsForDriver(query, _cancellationToken);

            //Assert
            result.Should().BeOfType(typeof(OkObjectResult));
            var objectResult = result as OkObjectResult;
            objectResult.Value.Should().NotBeNull();
            objectResult.Value.Should().BeOfType(typeof(GetFuelCardsForDriverQueryResult));
        }


        [Fact]
        public async Task Should_not_get_driver_vehicles()
        {
            //Arrange
            var query = new GetVehiclesForDriverQuery() { DriverId = driverId };
            var queryError = new ExecutionError("Id-Error", Constants.ErrorCodes.IdNotUnique);
            var queryRespons = ExecutionResult.BadRequest(queryError).As<GetVehiclesForDriverQueryResult>();

            _mediator.Setup(x => x.Send(
                    It.Is<GetVehiclesForDriverQuery>(y => y.DriverId == driverId),
                    It.Is<CancellationToken>(z => z.Equals(_cancellationToken))))
                .ReturnsAsync(queryRespons);

            //Act
            var result = await _controller.GetVehiclesForDriver(query, _cancellationToken);

            //Assert
            result.Should().BeOfType(typeof(BadRequestObjectResult)); 
            var objectResult = result as BadRequestObjectResult;
            objectResult.Value.Should().NotBeNull();
            objectResult.Value.Should().BeOfType(typeof(ExecutionResultDto));
        }

        [Fact]
        public async Task Should_get_driver_vehicles()
        {
            //Arrange
            var query = new GetVehiclesForDriverQuery() { DriverId = driverId };
            var queryRespons = new GetVehiclesForDriverQueryResult(new List<VehicleDetailsDto>());

            _mediator.Setup(x => x.Send(
                    It.Is<GetVehiclesForDriverQuery>(y => y.DriverId == driverId),
                    It.Is<CancellationToken>(z => z.Equals(_cancellationToken))))
                .ReturnsAsync(queryRespons);

            //Act
            var result = await _controller.GetVehiclesForDriver(query, _cancellationToken);

            //Assert
            result.Should().BeOfType(typeof(OkObjectResult));
            var objectResult = result as OkObjectResult;
            objectResult.Value.Should().NotBeNull();
            objectResult.Value.Should().BeOfType(typeof(GetVehiclesForDriverQueryResult));
        }
    }
}
