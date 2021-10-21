using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Features.DriverZone.AddAppeal;
using FleetManagement.BLL.Features.DriverZone.UpdateAppeal;
using FleetManagement.BLL.Features.DriverZone.UpdateContactInfo;
using FleetManagement.BLL.Features.DriverZone.UpdateFuelCard;
using FleetManagement.Framework.Constants;
using FleetManagement.WriteAPI.Controllers;
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
    public class WriteAPIDriverZoneControllerTests
    {
        private const int driverId = 1;
        private const int fuelCardId = 1;
        private const int appealId = 1;
        private readonly CancellationToken _cancellationToken = CancellationToken.None;
        private readonly Mock<IMediator> _mediator;
        private readonly DriverZoneController _controller;

        public WriteAPIDriverZoneControllerTests()
        {
            _mediator = new Mock<IMediator>();
            _controller = new DriverZoneController(_mediator.Object);
        }

        [Fact]
        public async Task Should_not_update_driver_contactInfo()
        {
            //Arrange
            var command = new UpdateContactInfoCommand { DriverId = driverId };
            var commandError = new ExecutionError("Id-Error", Constants.ErrorCodes.InvalidRequestInput);
            var commandRespons = ExecutionResult.BadRequest(commandError).As<UpdateContactInfoCommandResult>();

            _mediator.Setup(x => x.Send(
                It.Is<UpdateContactInfoCommand>(y => y.DriverId == driverId),
                It.Is<CancellationToken>(z => z.Equals(_cancellationToken))))
                .ReturnsAsync(commandRespons);

            //Act
            var result = await _controller.UpdateContactInfo(command, driverId, _cancellationToken);

            //Assert
            result.Should().BeOfType(typeof(BadRequestObjectResult));
            var objectResult = result as BadRequestObjectResult;
            objectResult.Value.Should().NotBeNull();
            objectResult.Value.Should().BeOfType(typeof(ExecutionResultDto));
        }

        [Fact]
        public async Task Should_update_driver_contactInfo()
        {
            //Arrange
            var command = new UpdateContactInfoCommand { DriverId = driverId };
            var commandRespons = new UpdateContactInfoCommandResult();

            _mediator.Setup(x => x.Send(
                    It.Is<UpdateContactInfoCommand>(y => y.DriverId == driverId),
                    It.Is<CancellationToken>(z => z.Equals(_cancellationToken))))
                .ReturnsAsync(commandRespons);

            //Act
            var result = await _controller.UpdateContactInfo(command, driverId, _cancellationToken);

            //Assert
            result.Should().BeOfType(typeof(OkObjectResult));
            var objectResult = result as OkObjectResult;
            objectResult.Value.Should().NotBeNull();
            objectResult.Value.Should().BeOfType(typeof(UpdateContactInfoCommandResult));
        }

        [Fact]
        public async Task Should_not_update_fuelCard_for_driver()
        {
            //Arrange
            var command = new UpdateFuelCardInfoCommand() { FuelCardId = fuelCardId };
            var commandError = new ExecutionError("Id-Error", Constants.ErrorCodes.InvalidRequestInput);
            var commandRespons = ExecutionResult.BadRequest(commandError).As<UpdateFuelCardInfoCommandResult>();

            _mediator.Setup(x => x.Send(
                It.Is<UpdateFuelCardInfoCommand>(y => y.FuelCardId == fuelCardId),
                It.Is<CancellationToken>(z => z.Equals(_cancellationToken))))
                .ReturnsAsync(commandRespons);

            //Act
            var result = await _controller.UpdateFuelCard(command, fuelCardId, _cancellationToken);

            //Assert
            result.Should().BeOfType(typeof(BadRequestObjectResult));
            var objectResult = result as BadRequestObjectResult;
            objectResult.Value.Should().NotBeNull();
            objectResult.Value.Should().BeOfType(typeof(ExecutionResultDto));
        }

        [Fact]
        public async Task Should_update_fuelCard_for_driver()
        {
            //Arrange
            var command = new UpdateFuelCardInfoCommand() { FuelCardId = fuelCardId };
            var commandRespons = new UpdateFuelCardInfoCommandResult();

            _mediator.Setup(x => x.Send(
                    It.Is<UpdateFuelCardInfoCommand>(y => y.FuelCardId == fuelCardId),
                    It.Is<CancellationToken>(z => z.Equals(_cancellationToken))))
                .ReturnsAsync(commandRespons);

            //Act
            var result = await _controller.UpdateFuelCard(command, fuelCardId, _cancellationToken);

            //Assert
            result.Should().BeOfType(typeof(OkObjectResult));
            var objectResult = result as OkObjectResult;
            objectResult.Value.Should().NotBeNull();
            objectResult.Value.Should().BeOfType(typeof(UpdateFuelCardInfoCommandResult));
        }

        [Fact]
        public async Task Should_not_update_appeal_for_driver()
        {
            //Arrange
            var command = new UpdateAppealInfoCommand() { AppealId = appealId };
            var commandError = new ExecutionError("Id-Error", Constants.ErrorCodes.InvalidRequestInput);
            var commandRespons = ExecutionResult.BadRequest(commandError).As<UpdateAppealInfoCommandResult>();

            _mediator.Setup(x => x.Send(
                    It.Is<UpdateAppealInfoCommand>(y => y.AppealId == appealId),
                    It.Is<CancellationToken>(z => z.Equals(_cancellationToken))))
                .ReturnsAsync(commandRespons);

            //Act
            var result = await _controller.UpdateAppealInfo(command, appealId, _cancellationToken);

            //Assert
            result.Should().BeOfType(typeof(BadRequestObjectResult));
            var objectResult = result as BadRequestObjectResult;
            objectResult.Value.Should().NotBeNull();
            objectResult.Value.Should().BeOfType(typeof(ExecutionResultDto));
        }


        [Fact]
        public async Task Should_update_appeal_for_driver()
        {
            //Arrange
            var command = new UpdateAppealInfoCommand() { AppealId = appealId };
            var commandRespons = new UpdateAppealInfoCommandResult();

            _mediator.Setup(x => x.Send(
                    It.Is<UpdateAppealInfoCommand>(y => y.AppealId == appealId),
                    It.Is<CancellationToken>(z => z.Equals(_cancellationToken))))
                .ReturnsAsync(commandRespons);

            //Act
            var result = await _controller.UpdateAppealInfo(command, appealId, _cancellationToken);

            //Assert
            result.Should().BeOfType(typeof(OkObjectResult));
            var objectResult = result as OkObjectResult;
            objectResult.Value.Should().NotBeNull();
            objectResult.Value.Should().BeOfType(typeof(UpdateAppealInfoCommandResult));
        }

        [Fact]
        public async Task Should_not_add_appeal_for_driver()
        {
            //Arrange
            var command = new AddAppealCommand() { DriverId = driverId };
            var commandError = new ExecutionError("Id-Error", Constants.ErrorCodes.InvalidRequestInput);
            var commandRespons = ExecutionResult.BadRequest(commandError).As<AddAppealCommandResult>();

            _mediator.Setup(x => x.Send(
                    It.Is<AddAppealCommand>(y => y.DriverId == driverId),
                    It.Is<CancellationToken>(z => z.Equals(_cancellationToken))))
                .ReturnsAsync(commandRespons);

            //Act
            var result = await _controller.AddAppeal(command, _cancellationToken);

            //Assert
            result.Should().BeOfType(typeof(BadRequestObjectResult));
            var objectResult = result as BadRequestObjectResult;
            objectResult.Value.Should().NotBeNull();
            objectResult.Value.Should().BeOfType(typeof(ExecutionResultDto));
        }

        [Fact]
        public async Task Should_add_appeal_for_driver()
        {
            //Arrange
            var command = new AddAppealCommand() { DriverId = driverId };
            var commandRespons = new AddAppealCommandResult();

            _mediator.Setup(x => x.Send(
                    It.Is<AddAppealCommand>(y => y.DriverId == driverId),
                    It.Is<CancellationToken>(z => z.Equals(_cancellationToken))))
                .ReturnsAsync(commandRespons);

            //Act
            var result = await _controller.AddAppeal(command, _cancellationToken);

            //Assert
            result.Should().BeOfType(typeof(OkObjectResult));
            var objectResult = result as OkObjectResult;
            objectResult.Value.Should().NotBeNull();
            objectResult.Value.Should().BeOfType(typeof(AddAppealCommandResult));
        }
    }
}
