﻿using AutoMapper;
using FleetManagement.BLL.Mapper.Converters;
using FleetManagement.Domain.Models;
using FleetManagement.Framework.Models.Dtos.ReadDtos;
using FleetManagement.Framework.Models.Dtos.WriteDtos;
using FleetManagement.Framework.Models.WriteDtos;
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

            CreateMap<Driver, DriverDetailsDto>()
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

            CreateMap<Driver, AppealDto>()
                .ReverseMap();

            CreateMap<Appeal, AppealDto>()
                .ReverseMap();

            CreateMap<DriverVehicle, VehicleDetailsDto>()
                .ReverseMap();

            CreateMap<IdentityVehicle, IdentityVehicleDto>()
                .ReverseMap();

            CreateMap<DriverVehicle, DriverVehicleDto>()
                .ReverseMap();

            CreateMap<Maintenance, MaintenanceDto>()
                .ReverseMap();

            CreateMap<Repare, RepareDto>()
                .ReverseMap();

            CreateMap<Vehicle, VehicleDetailsDto>()
                .ReverseMap();

            CreateMap<Vehicle, VehicleDetailsDto>()
                .ReverseMap();

            CreateMap<Driver, AddDriverDto>()
                .ReverseMap();

            CreateMap<DriverVehicle, AddDriverVehicleDto>()
                .ReverseMap();

            CreateMap<FuelCardDriver, AddFuelCardDriverDto>()
                .ReverseMap();

            //Extra convertingmaps
            CreateMap<string, List<string>>().ConvertUsing<StringToStringsConverter>();
            CreateMap<string, List<int>>().ConvertUsing<StringToIntsConverter>();
        }
    }
}
