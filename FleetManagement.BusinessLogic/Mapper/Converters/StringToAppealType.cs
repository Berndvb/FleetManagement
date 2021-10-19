using AutoMapper;
using FleetManagement.Framework.Helpers;
using FleetManagement.Framework.Models.Enums;

namespace FleetManagement.BLL.Mapper.Converters
{
    public class StringToAppealType : ITypeConverter<string, AppealType>
    {
        public AppealType Convert(string source, AppealType destination, ResolutionContext context)
        {
            return source.StringToAppealType();
        }
    }
}
