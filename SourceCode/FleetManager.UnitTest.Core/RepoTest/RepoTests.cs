using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FleetManagement.Domain.Models;
using FleetManagement.Framework.Paging;
using FleetManager.EFCore.Infrastructure.DbContext;
using FleetManager.EFCore.Infrastructure.Pagination;
using FleetManager.EFCore.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using Xunit;

namespace FleetManager.UnitTest.Core.RepoTest
{
    /// <summary>
    /// Can the repository:
    /// - accept a DbContext and make a DbSet to query upon?
    /// - have working methods (with functional filtering, including and pagination)?
    /// </summary>
    /// <returns></returns>
    public class RepoTests
    {
        private int driverId = 1;
        private readonly CancellationToken _cancellationToken = CancellationToken.None;
        //private readonly Mock<DatabaseContext> _dbContext;
        private readonly Mock<DbSet<Driver>> _dbSet;



        public RepoTests()
        {
            //_dbContext = new Mock<DatabaseContext>(new Mock<DbContextOptions<DatabaseContext>>().Object);
            _dbSet = new Mock<DbSet<Driver>>();
        }

        [Fact]
        public async Task Should_get_filtered_driverList_by_id()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Products Test")
                .Options;

            using (var context = new DatabaseContext(options))
            {
                //Arrange

                var pagingParameters = new PagingParameters { PageSize = 5, PageNumber = 1 };

                Expression<Func<Driver, bool>> filter = x => x.Id.Equals(driverId);
                Func<IQueryable<Driver>, IIncludableQueryable<Driver, object>> including = null;

                var filteredReturn = new List<Driver> { new Driver { Id = 99 } };
                var regularReturn = new List<Driver> { new Driver { Id = 99 }, new Driver { Id = 199 } };

                var repo = new GenericRepository<Driver>(context);
                var drivers = new List<Driver>{new Driver{Id = 1}, new Driver{Id = 2}};
                context.Drivers.AddRange(drivers);
                context.Drivers.Add(drivers[1]);
                context.SaveChanges();
                var test = context.Drivers.Count();

                //Act

                var result = await repo.GetListBy(_cancellationToken, pagingParameters);

                //Assert
                result.Count.Should().Be(2);
            }
        }
    }
}
