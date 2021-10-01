using AutoMapper;
using FleetManagement.BLL.Mapper.Converters;
using FleetManagement.Domain.Models;
using FleetManagement.Framework.Models.Dtos;
using FleetManagement.Framework.Models.Dtos.ShowDtos;
using System.Collections.Generic;

namespace FleetManagement.BLL.Services
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Driver, DriverOverviewDto>()
                .ReverseMap();

            CreateMap<Driver, DriverDetailsDto>()
                .ReverseMap();

            CreateMap<Driver, DriverDto>()
                .ReverseMap();

            CreateMap<IdentityPerson, IdentityPersonDto>()
                .ReverseMap();

            CreateMap<ContactInfo, ContactInfoDto>()
                .ReverseMap();

            CreateMap<Address, AddressDto>()
                .ReverseMap();

            CreateMap<Driver, AppealDto>()
                .ReverseMap();

            CreateMap<Appeal, AppealDto>()
                .ReverseMap();

            CreateMap<Vehicle, VehicleOverviewDto>()
                .ReverseMap();

            CreateMap<Appeal, AppealDto>()
                .ReverseMap();

            CreateMap<FuelCardOptions, FuelCardOptionsDto>()
                .ReverseMap();

            CreateMap<Vehicle, VehicleOverviewDto>()
                .ReverseMap();

            CreateMap<Driver, FuelCardDto>()
                .ReverseMap();

            CreateMap<FuelCard, FuelCardDto>()
                .ReverseMap();

            CreateMap<FuelCardOptions, FuelCardOptionsDto>()
                .ReverseMap();

            CreateMap<Driver, VehicleAppealDto>()
                .ReverseMap();

            CreateMap<Appeal, VehicleAppealDto>()
                .ReverseMap();

            CreateMap<DriverVehicle, VehicleDetailsDto>()
                .ReverseMap();

            CreateMap<IdentityVehicle, IdentityVehicleDto>()
                .ReverseMap();

            CreateMap<DriverVehicle, DriverVehicleDto>()
                .ReverseMap();

            CreateMap<Maintenance, VehicleMaintenanceDto>()
                .ReverseMap();

            CreateMap<Repare, VehicleRepareDto>()
                .ReverseMap();

            CreateMap<Vehicle, VehicleDto>()
                .ReverseMap();

            CreateMap<Vehicle, VehicleDetailsDto>()
                .ReverseMap();

            //Extra convertingmaps
            CreateMap<string, List<string>>().ConvertUsing<StringToStringsConverter>();
            CreateMap<string, List<int>>().ConvertUsing<StringToIntsConverter>();
        }
    }
}
