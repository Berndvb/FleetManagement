using AutoMapper;
using FleetManagement.Domain.Models;
using FleetManagement.Framework.Models.Dtos;

namespace FleetManagement.BLL.Services
{
    public class MapperService : Profile
    {
        public MapperService()
        {
            CreateMap<Driver, ShowDriverOverviewDto>();
        }
    }
}
