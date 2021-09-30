using AutoMapper;
using FleetManagement.Framework.Helpers;
using System.Collections.Generic;

namespace FleetManagement.BLL.Mapper.Converters
{
    public class StringToIntsConverter : ITypeConverter<string, List<int>>
    {
        public List<int> Convert(string source, List<int> destination, ResolutionContext context)
        {
            return source.SplitToNumbers();
        }
    }
}
