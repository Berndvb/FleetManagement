using System.Net;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManager.UnitTest.Features.DriverZone.Factory;
using Xunit;
using FleetManager.UnitTest.Http;
using FluentAssertions;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace FleetManager.UnitTest
{
    public class DriverZoneTests : IClassFixture<DriverZoneFactory>
    {
        private readonly DriverZoneFactory _factory;

        public DriverZoneTests(DriverZoneFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Should_get_driverDetailsAsync()
        {

            // Arrange
            var driverId = 1;

            var client = await _factory
                .WithDriverDetails(driverId)
                .SwapService()
                .CreateClient();

            var url = $"https://localhost:44331/readapi/Driver/2/driverdetails";

            // Act
            var respons = await client.GetAsync<DriverDetailsDto>(url);

            // Assert
            respons.ResponseMessage.StatusCode.Should().Be(HttpStatusCode.OK);

        }
    }
}
