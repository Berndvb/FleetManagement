using AutoMapper;
using FleetManagement.Domain.Models;
using FleetManagement.Framework.Models.Dtos.ShowDtos;

namespace FleetManagement.BLL.Services
{
    public class MapperService : Profile
    {
        public MapperService()
        {
            CreateMap<Driver, DriverOverviewDto>();
            CreateMap<Driver, DriverDetailsDto>();
            CreateMap<Driver, VehicleInfoDto>();
        }
    }
}
