using FleetManagement.Domain.Models;
using FleetManagement.Framework.Paging;
using FleetManager.EFCore.Repositories;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManager.UnitTest.Integration.Setup
{
    public class DriverZoneClientFactory : AuthenticatedFixture<DriverZoneClientFactory>
    {
        private readonly string _assemblyName;
        private readonly Mock<IGenericRepository<Driver>> _mockDriverRepository;
        private readonly Mock<IGenericRepository<Appeal>> _mockAppealRepository;
        private readonly Mock<IGenericRepository<Vehicle>> _mockVehicleRepository;
        private readonly Mock<IGenericRepository<FuelCard>> _mockFuelCardRepository;


        public DriverZoneClientFactory()
        {
            _assemblyName = Assembly.GetAssembly(typeof(DriverZoneClientFactory)).GetName().Name;
            _mockDriverRepository = new Mock<IGenericRepository<Driver>>();
            _mockAppealRepository = new Mock<IGenericRepository<Appeal>>();
            _mockVehicleRepository = new Mock<IGenericRepository<Vehicle>>();
            _mockFuelCardRepository = new Mock<IGenericRepository<FuelCard>>();
        }

        public override Task<HttpClient> CreateClient()
        {
            Registrations.Add(services => { services.SwapTransient(provider => _mockDriverRepository.Object); });
            Registrations.Add(services => { services.SwapTransient(provider => _mockAppealRepository.Object); });
            Registrations.Add(services => { services.SwapTransient(provider => _mockVehicleRepository.Object); });
            Registrations.Add(services => { services.SwapTransient(provider => _mockFuelCardRepository.Object); });

            return base.CreateClient();
        }

        public DriverZoneClientFactory WithDrivers()
        {
            var entityResponse = ReadResponseFromEmbeddedFile<List<Driver>>(
                _assemblyName, $"GetDrivers.json");

            _mockDriverRepository.Setup(x => x.GetListBy(
                    It.IsAny<CancellationToken>(),
                    It.IsAny<PagingParameters>(),
                    It.IsAny<Expression<Func<Driver, bool>>>(),
                    It.IsAny<Func<IQueryable<Driver>, IIncludableQueryable<Driver, object>>>()))
                .ReturnsAsync(entityResponse);

            return this;
        }

        public DriverZoneClientFactory WithDriverById()
        {
            var entityResponse = ReadResponseFromEmbeddedFile<Driver>(
                _assemblyName, $"GetDriverById.json");

            _mockDriverRepository.Setup(x => x.GetBy(
                    It.IsAny<CancellationToken>(),
                    It.IsAny<Expression<Func<Driver, bool>>>(),
                    It.IsAny<Func<IQueryable<Driver>, IIncludableQueryable<Driver, object>>>()))
                .ReturnsAsync(entityResponse);

            return this;
        }

        public DriverZoneClientFactory WithAppealsForDriver()
        {
            var entityResponse = ReadResponseFromEmbeddedFile<List<Appeal>>(
                _assemblyName, $"GetAppealsForDriver.json");

            _mockAppealRepository.Setup(x => x.GetListBy(
                    It.IsAny<CancellationToken>(),
                    It.IsAny<PagingParameters>(),
                    It.IsAny<Expression<Func<Appeal, bool>>>(),
                    It.IsAny<Func<IQueryable<Appeal>, IIncludableQueryable<Appeal, object>>>()))
                .ReturnsAsync(entityResponse);

            return this;
        }

        public DriverZoneClientFactory WithFuelCardsForDriver()
        {
            var entityResponse = ReadResponseFromEmbeddedFile<List<FuelCard>>(
                _assemblyName, $"GetFuelCardsForDriver.json");

            _mockFuelCardRepository.Setup(x => x.GetListBy(
                    It.IsAny<CancellationToken>(),
                    It.IsAny<PagingParameters>(),
                    It.IsAny<Expression<Func<FuelCard, bool>>>(),
                    It.IsAny<Func<IQueryable<FuelCard>, IIncludableQueryable<FuelCard, object>>>()))
                .ReturnsAsync(entityResponse);

            return this;
        }

        public DriverZoneClientFactory WithVehiclesForDriver()
        {
            var entityResponse = ReadResponseFromEmbeddedFile<List<Vehicle>>(
                _assemblyName, $"GetFuelCardsForDriver.json");

            _mockVehicleRepository.Setup(x => x.GetListBy(
                    It.IsAny<CancellationToken>(),
                    It.IsAny<PagingParameters>(),
                    It.IsAny<Expression<Func<Vehicle, bool>>>(),
                    It.IsAny<Func<IQueryable<Vehicle>, IIncludableQueryable<Vehicle, object>>>()))
                .ReturnsAsync(entityResponse);

            return this;
        }

        public DriverZoneClientFactory WithAddAppeal()
        {
            _mockAppealRepository.Setup(x => x.Insert(
                    It.IsAny<Appeal>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            return this;
        }

        public DriverZoneClientFactory WithUpdateAppealInfo()
        {
            _mockAppealRepository.Setup(x => x.Update(
                    It.IsAny<Appeal>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            return this;
        }

        public DriverZoneClientFactory WithUpdateContactInfo()
        {
            _mockDriverRepository.Setup(x => x.Update(
                    It.IsAny<Driver>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            return this;
        }

        public DriverZoneClientFactory WithUpdateFuelCardInfo()
        {
            _mockFuelCardRepository.Setup(x => x.Update(
                    It.IsAny<FuelCard>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            return this;
        }

        public Result<T> Ok<T>(T value)
        {
            return new Result<T>(value, true, null);
        }
    }
}
