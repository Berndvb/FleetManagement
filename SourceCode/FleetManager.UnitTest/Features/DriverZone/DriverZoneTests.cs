using System;
using FleetManager.UnitTest.Features.DriverZone.Factory;
using Xunit;

namespace FleetManager.UnitTest
{
    public class DriverZoneTests : IClassFixture<DriverZoneClientFactory>
    {
        private readonly DriverZoneClientFactory _factory;

        public DriverZoneTests(DriverZoneClientFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public void Should_Get_DriverDetails()
        {
            var driverId = 1;

            var client = await _factory
                .GetDriverDetails(driverId)
                .CreateClient();
        }
    }
}
