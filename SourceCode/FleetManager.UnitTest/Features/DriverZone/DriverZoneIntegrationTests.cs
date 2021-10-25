using System.Threading.Tasks;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManager.UnitTest.Integration.Setup;
using Xunit;

namespace FleetManager.UnitTest.Integration.Features.DriverZone
{
    public class DriverZoneTests : IClassFixture<DriverZoneClientFactory>
    {
        private static string CustomerZoneRoute => "api/v1/my";
        public DriverZoneClientFactory _factory;
        public DriverZoneTests(DriverZoneClientFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Should_get_driverDetailsAsync()
        {
            // Arrange
            var client = await _factory
                .WithDriverById()
                .CreateClient();

            // Act
            var url = $"readapi/driver/1";
            var result = client.GetAsync<DriverDetailsDto>(url);

            // Assert

        }
    }
}