using FleetManagement.Domain.Models;
using FleetManagement.Framework.Paging;
using FleetManager.EFCore.Infrastructure.DbContext;
using FleetManager.EFCore.Infrastructure.Pagination;
using FleetManager.EFCore.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FleetManager.UnitTest.Core.RepoTest
{
    /// <summary>
    /// Can the repository:
    /// - accept a TEntity and DbContext, and consequently form a propper DbSet to work up?
    /// - have working methods (with functional filtering, including and pagination)?
    /// </summary>
    /// <returns></returns>
    public class RepoTests
    {
        private const int driverId = 1;
        private readonly CancellationToken _cancellationToken = CancellationToken.None;

        public RepoTests()
        {
        }

        [Fact]
        public async Task Should_get_filtered_driverList_by_inService()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "DriverZoneTest")
                .Options;

            using (var context = new DatabaseContext(options))
            {
                //Arrange
                var drivers = new List<Driver> { new Driver { Id = 1, InService = true }, new Driver { Id = 2, InService = false } };
                context.Drivers.AddRange(drivers);
                context.SaveChanges();
                Expression<Func<Driver, bool>> filter = x => x.InService.Equals(true);
                var repo = new GenericRepository<Driver>(context);

                //Act
                var result = await repo.GetListBy(_cancellationToken, pagingParameters: null, filter, including: null);

                //Assert
                result.Count.Should().Be(1);
                result.FirstOrDefault().Id.Should().Be(driverId);
                result.Should().BeOfType(typeof(List<Driver>));

                context.Database.EnsureDeleted();
            }
        }

        [Fact]
        public async Task Should_get_paginated_driverList()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "DriverZoneTest")
                .Options;

            using (var context = new DatabaseContext(options))
            {
                //Arrange
                var drivers = new List<Driver> { new Driver { Id = 1, InService = true }, new Driver { Id = 2, InService = false } };
                context.Drivers.AddRange(drivers);
                context.SaveChanges();
                var pagingParameters = new PagingParameters { PageSize = 5, PageNumber = 1 };
                var repo = new GenericRepository<Driver>(context);

                //Act
                var result = await repo.GetListBy(_cancellationToken, pagingParameters, filter: null, including: null);

                //Assert
                result.Count.Should().Be(2);
                result.Should().BeOfType(typeof(PaginatedList<Driver>));
                var paginatedResult = result as PaginatedList<Driver>;
                paginatedResult.PageNumber.Should().Be(1);
                paginatedResult.PageSize.Should().Be(5);
                paginatedResult.HasNextPage.Should().BeFalse();
                paginatedResult.HasPreviousPage.Should().BeFalse();
                paginatedResult.TotalCount.Should().Be(2);
                paginatedResult.TotalCount.Should().Equals(paginatedResult.Count());

                context.Database.EnsureDeleted();
            }
        }

        [Fact]
        public async Task Should_get_driverList_with_inclusions()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "DriverZoneTest")
                .Options;

            using (var context = new DatabaseContext(options))
            {
                //Arrange
                var identity = new IdentityPerson { Id = 1, Name = "TestName", FirstName = "TestFirstName" };
                var drivers = new List<Driver> { new Driver { Id = 1, InService = true, Identity = identity }, new Driver { Id = 2, InService = false } };
                context.Drivers.AddRange(drivers);
                context.SaveChanges();
                Func<IQueryable<Driver>, IIncludableQueryable<Driver, object>> including = x => x.Include(y => y.Identity);
                var repo = new GenericRepository<Driver>(context);

                //Act
                var result = await repo.GetListBy(_cancellationToken, pagingParameters: null, filter: null, including);

                //Assert
                result.Count.Should().Be(2);
                result.Should().BeOfType(typeof(List<Driver>));
                var resultIdentity = result.SingleOrDefault(x => x.Id.Equals(driverId)).Identity;
                resultIdentity.Should().NotBeNull();
                resultIdentity.FirstName.Should().Be("TestFirstName");
                resultIdentity.Name.Should().Be("TestName");

                context.Database.EnsureDeleted();
            }
        }


        [Fact]
        public async Task Should_get_filtered_driver_by_id()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "DriverZoneTest")
                .Options;

            using (var context = new DatabaseContext(options))
            {
                //Arrange
                var driver = new Driver { Id = 1, InService = true };
                context.Drivers.Add(driver);
                context.SaveChanges();
                Expression<Func<Driver, bool>> filter = x => x.Id.Equals(driverId);
                var repo = new GenericRepository<Driver>(context);

                //Act
                var result = await repo.GetBy(_cancellationToken, filter, including: null);

                //Assert
                result.Id.Should().Be(driverId);
                result.Should().BeOfType(typeof(Driver));

                context.Database.EnsureDeleted();
            }
        }

        [Fact]
        public async Task Should_get_filtered_driver_by_id_with_inclusions()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "DriverZoneTest")
                .Options;

            using (var context = new DatabaseContext(options))
            {
                //Arrange
                var identity = new IdentityPerson { Id = 1, Name = "TestName", FirstName = "TestFirstName" };
                var driver = new Driver { Id = 1, InService = true, Identity = identity };
                context.Drivers.Add(driver);
                context.SaveChanges();
                Expression<Func<Driver, bool>> filter = x => x.Id.Equals(driverId);
                Func<IQueryable<Driver>, IIncludableQueryable<Driver, object>> including = x => x.Include(y => y.Identity);
                var repo = new GenericRepository<Driver>(context);

                //Act
                var result = await repo.GetBy(_cancellationToken, filter, including);

                //Assert
                result.Id.Should().Be(driverId);
                result.Should().BeOfType(typeof(Driver));
                result.Identity.Should().NotBeNull();
                result.Identity.FirstName.Should().Be("TestFirstName");
                result.Identity.Name.Should().Be("TestName");

                context.Database.EnsureDeleted();
            }
        }

        [Fact]
        public async Task Should_get_ids()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "DriverZoneTest")
                .EnableSensitiveDataLogging()
                .Options;

            using (var context = new DatabaseContext(options))
            {
                //Arrange
                var drivers = new List<Driver> { new Driver { Id = 1, InService = true }, new Driver { Id = 2, InService = false } };
                context.Drivers.AddRange(drivers);
                context.SaveChanges();
                Expression<Func<Driver, bool>> filter = x => x.Id.Equals(driverId);
                var repo = new GenericRepository<Driver>(context);

                //Act
                var result = await repo.GetIds(driverId, _cancellationToken);

                //Assert
                result.Count.Should().Be(1);
                result.ForEach(x => x.Should().Be(driverId));
                result.Should().BeOfType(typeof(List<int>));

                context.Database.EnsureDeleted();
            }
        }

        [Fact]
        public async Task Should_insert_entity_with_including()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "DriverZoneTest")
                .EnableSensitiveDataLogging()
                .Options;

            using (var context = new DatabaseContext(options))
            {
                //Arrange
                var identity = new IdentityPerson { Id = 1, Name = "TestName", FirstName = "TestFirstName" };
                var driver = new Driver { Id = 1, InService = true, Identity = identity };
                var repo = new GenericRepository<Driver>(context);

                //Act
                await repo.Insert(driver, _cancellationToken);
                context.SaveChanges();

                //Assert
                context.Drivers.Count().Should().Be(1);
                var foundDriver = context.Drivers.First();
                foundDriver.Id.Should().Be(driverId);
                foundDriver.Identity.FirstName.Should().Be("TestFirstName");
                foundDriver.Identity.Name.Should().Be("TestName");

                context.Database.EnsureDeleted();
            }
        }

        [Fact]
        public async Task Should_insert_entities_with_including()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "DriverZoneTest")
                .EnableSensitiveDataLogging()
                .Options;

            using (var context = new DatabaseContext(options))
            {
                //Arrange
                var identity = new IdentityPerson { Id = 1, Name = "TestName", FirstName = "TestFirstName" };
                var drivers = new List<Driver> { new Driver { Id = 1, InService = true, Identity = identity }, new Driver { Id = 2, InService = false } };
                var repo = new GenericRepository<Driver>(context);

                //Act
                await repo.InsertRange(drivers, _cancellationToken);
                context.SaveChanges();

                //Assert
                context.Drivers.Count().Should().Be(2);
                var firstDriver = context.Drivers.First();
                firstDriver.Id.Should().Be(driverId);
                firstDriver.Identity.FirstName.Should().Be("TestFirstName");
                firstDriver.Identity.Name.Should().Be("TestName");

                context.Database.EnsureDeleted();
            }
        }

        [Fact]
        public async Task Should_remove_entity()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "DriverZoneTest")
                .EnableSensitiveDataLogging()
                .Options;

            using (var context = new DatabaseContext(options))
            {
                //Arrange
                var driverFirst = new Driver { Id = 1, InService = true };
                var driverSecond = new Driver { Id = 2, InService = false };
                context.Drivers.AddRange(driverFirst, driverSecond);
                context.SaveChanges();
                var repo = new GenericRepository<Driver>(context);

                //Act
                await repo.Remove(driverSecond, _cancellationToken);
                context.SaveChanges();

                //Assert
                context.Drivers.Count().Should().Be(1);
                var firstDriver = context.Drivers.First();
                firstDriver.Id.Should().Be(driverId);

                context.Database.EnsureDeleted();
            }
        }

        [Fact]
        public async Task Should_only_remove_identity()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "DriverZoneTest")
                .EnableSensitiveDataLogging()
                .Options;

            using (var context = new DatabaseContext(options))
            {
                //Arrange
                var repo = new GenericRepository<IdentityPerson>(context);
                var identity = new IdentityPerson { Id = 1, Name = "TestName", FirstName = "TestFirstName" };
                var drivers = new List<Driver> { new Driver { Id = 1, InService = true, Identity = identity }, new Driver { Id = 2, InService = false } };
                context.Drivers.AddRange(drivers);
                context.SaveChanges();

                //Act
                await repo.Remove(identity, _cancellationToken);
                context.SaveChanges();

                //Assert
                context.Drivers.Count().Should().Be(2);
                var firstDriver = context.Drivers.First();
                firstDriver.Id.Should().Be(driverId);
                firstDriver.Identity.Should().BeNull();

                context.Database.EnsureDeleted();
            }
        }

        [Fact]
        public async Task Should_update_entity()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "DriverZoneTest")
                .EnableSensitiveDataLogging()
                .Options;

            using (var context = new DatabaseContext(options))
            {
                //Arrange
                var drivers = new List<Driver> { new Driver { Id = 1, InService = true }, new Driver { Id = 2, InService = false } };
                context.Drivers.AddRange(drivers);
                context.SaveChanges();
                var driverFound = context.Drivers.SingleOrDefault(x => x.Id.Equals(driverId));
                driverFound.InService = false;
                var repo = new GenericRepository<Driver>(context);

                //Act
                await repo.Update(driverFound, _cancellationToken);
                context.SaveChanges();

                //Assert
                context.Drivers.Count().Should().Be(2);
                var relevantDriver = context.Drivers.SingleOrDefault(x => x.Id.Equals(driverId));
                relevantDriver.Id.Should().Be(driverId);
                relevantDriver.InService.Should().BeFalse();

                context.Database.EnsureDeleted();
            }
        }
    }
}
