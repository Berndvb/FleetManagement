﻿using FleetManagement.BLL.Features.DriverZone.AddAppeal;
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
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FleetManager.UnitTest.Core
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
        const int driverId = 1;
        const int fuelCardId = 1;
        const int appealId = 1;
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
            var cancellationToken = CancellationToken.None;

            _mediator.Setup(x => x.Send(
                It.Is<UpdateContactInfoCommand>(y => y.DriverId == driverId),
                It.Is<CancellationToken>(z => z.Equals(cancellationToken))))
                .ReturnsAsync(commandRespons);

            //Act
            var result = await _controller.UpdateContactInfo(command, driverId, cancellationToken);

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
            var cancellationToken = CancellationToken.None;

            _mediator.Setup(x => x.Send(
                    It.Is<UpdateContactInfoCommand>(y => y.DriverId == driverId),
                    It.Is<CancellationToken>(z => z.Equals(cancellationToken))))
                .ReturnsAsync(commandRespons);

            //Act
            var result = await _controller.UpdateContactInfo(command, driverId, cancellationToken);

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
            var command = new UpdateFuelCardCommand() { FuelCardId = fuelCardId };
            var commandError = new ExecutionError("Id-Error", Constants.ErrorCodes.InvalidRequestInput);
            var commandRespons = ExecutionResult.BadRequest(commandError).As<UpdateFuelCardCommandResult>();
            var cancellationToken = CancellationToken.None;

            _mediator.Setup(x => x.Send(
                It.Is<UpdateFuelCardCommand>(y => y.FuelCardId == fuelCardId),
                It.Is<CancellationToken>(z => z.Equals(cancellationToken))))
                .ReturnsAsync(commandRespons);

            //Act
            var result = await _controller.UpdateFuelCard(command, fuelCardId, cancellationToken);

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
            var command = new UpdateFuelCardCommand() { FuelCardId = fuelCardId };
            var commandRespons = new UpdateFuelCardCommandResult();
            var cancellationToken = CancellationToken.None;

            _mediator.Setup(x => x.Send(
                    It.Is<UpdateFuelCardCommand>(y => y.FuelCardId == fuelCardId),
                    It.Is<CancellationToken>(z => z.Equals(cancellationToken))))
                .ReturnsAsync(commandRespons);

            //Act
            var result = await _controller.UpdateFuelCard(command, fuelCardId, cancellationToken);

            //Assert
            result.Should().BeOfType(typeof(OkObjectResult));
            var objectResult = result as OkObjectResult;
            objectResult.Value.Should().NotBeNull();
            objectResult.Value.Should().BeOfType(typeof(UpdateFuelCardCommandResult));
        }

        [Fact]
        public async Task Should_not_update_appeal_for_driver()
        {
            //Arrange
            var command = new UpdateAppealInfoCommand() { AppealId = appealId };
            var commandError = new ExecutionError("Id-Error", Constants.ErrorCodes.InvalidRequestInput);
            var commandRespons = ExecutionResult.BadRequest(commandError).As<UpdateAppealInfoCommandResult>();
            var cancellationToken = CancellationToken.None;

            _mediator.Setup(x => x.Send(
                    It.Is<UpdateAppealInfoCommand>(y => y.AppealId == appealId),
                    It.Is<CancellationToken>(z => z.Equals(cancellationToken))))
                .ReturnsAsync(commandRespons);

            //Act
            var result = await _controller.UpdateAppealInfo(command, appealId, cancellationToken);

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
            var cancellationToken = CancellationToken.None;

            _mediator.Setup(x => x.Send(
                    It.Is<UpdateAppealInfoCommand>(y => y.AppealId == appealId),
                    It.Is<CancellationToken>(z => z.Equals(cancellationToken))))
                .ReturnsAsync(commandRespons);

            //Act
            var result = await _controller.UpdateAppealInfo(command, appealId, cancellationToken);

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
            var cancellationToken = CancellationToken.None;

            _mediator.Setup(x => x.Send(
                    It.Is<AddAppealCommand>(y => y.DriverId == driverId),
                    It.Is<CancellationToken>(z => z.Equals(cancellationToken))))
                .ReturnsAsync(commandRespons);

            //Act
            var result = await _controller.AddAppeal(command, cancellationToken);

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
            var cancellationToken = CancellationToken.None;

            _mediator.Setup(x => x.Send(
                    It.Is<AddAppealCommand>(y => y.DriverId == driverId),
                    It.Is<CancellationToken>(z => z.Equals(cancellationToken))))
                .ReturnsAsync(commandRespons);

            //Act
            var result = await _controller.AddAppeal(command, cancellationToken);

            //Assert
            result.Should().BeOfType(typeof(OkObjectResult));
            var objectResult = result as OkObjectResult;
            objectResult.Value.Should().NotBeNull();
            objectResult.Value.Should().BeOfType(typeof(AddAppealCommandResult));
        }
    }
}
