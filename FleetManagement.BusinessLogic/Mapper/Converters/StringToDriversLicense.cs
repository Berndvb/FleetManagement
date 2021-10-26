using AutoMapper;
using FleetManagement.Framework.Helpers;
using FleetManagement.Framework.Models.Enums;

namespace FleetManagement.BLL.Mapper.Converters
{
    internal class StringToDriversLicense : ITypeConverter<string, DriversLicenseType>
    {
        public DriversLicenseType Convert(string source, DriversLicenseType destination, ResolutionContext context)
        {
            return source.StringToDriversLicense();
        }
    }
}
