using AutoMapper;
using FleetManagement.Framework.Helpers;
using System.Collections.Generic;

namespace FleetManagement.BLL.Mapper.Converters
{
    class StringToIntsTypeConverter : ITypeConverter<string, List<string>>
    {
        public List<string> Convert(string source, List<string> destination, ResolutionContext context)
        {
            return source.SplitToText();
        }
    }
}
