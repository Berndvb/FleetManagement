using AutoMapper;
using FleetManagement.Domain.Models;
using FleetManagement.Framework.Models.Dtos.ShowDtos;

namespace FleetManagement.BLL.Services
{
    public class MapperService : Profile
    {
        public MapperService()
        {
            CreateMap<Driver, DriverOverviewDto>().ForMember(x => x.Name, y => y.MapFrom(z => z.Identity.Name)); 

            CreateMap<Driver, DriverDetailsDto>();


            //Vehicle

            //Vehicle Identity

            //VehicleMaintenance

            //VehicleRepares

            //VehicleAppeals

        }
    }
}
