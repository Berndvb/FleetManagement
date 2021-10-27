using AutoMapper;
using FleetManagement.Framework.Helpers;
using FleetManagement.Framework.Models.Enums;

namespace FleetManagement.BLL.Mapper.Converters
{
    internal class StringToAppealStatus : ITypeConverter<string, AppealStatus>
    {
        public AppealStatus Convert(string source, AppealStatus destination, ResolutionContext context)
        {
            return source.StringToAppealStatus();
        }
    }
}
