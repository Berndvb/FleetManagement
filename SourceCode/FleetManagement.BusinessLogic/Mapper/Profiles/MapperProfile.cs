using AutoMapper;
using FleetManagement.BLL.Mapper.Converters;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManagement.Domain.Models;
using FleetManagement.Framework.Models.Enums;
using System.Collections.Generic;

namespace FleetManagement.BLL.Mapper.Profiles
{
    internal class MapperProfile : Profile
    {
        internal MapperProfile()
        {
            CreateMap<Driver, DriverOverviewDto>()
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.Identity.FirstName))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Identity.Name))
                .ReverseMap();

            CreateMap<Driver, DriverDetailsDto>()
                .ReverseMap();

            CreateMap<IdentityPerson, IdentityPersonDto>()
                .ReverseMap();

            CreateMap<ContactInfo, ContactInfoDto>()
                .ReverseMap();

            CreateMap<Address, AddressDto>()
                .ReverseMap();

            CreateMap<Vehicle, VehicleOverviewDto>()
                .ForMember(x => x.Brand, y => y.MapFrom(z => z.Identity.Brand))
                .ForMember(x => x.Model, y => y.MapFrom(z => z.Identity.Model))
                .ReverseMap();

            CreateMap<FuelCard, FuelCardDto>()
                .ReverseMap();
            CreateMap<FuelCardDriver, FuelCardDriverDto>()
                .ReverseMap();
            CreateMap<FuelCardOptions, FuelCardOptionsDto>()
                .ReverseMap();

            CreateMap<Appeal, AppealDto>()
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

            //Extra convertingmaps
            CreateMap<string, List<string>>().ConvertUsing<StringToStringsConverter>();
            CreateMap<string, List<int>>().ConvertUsing<StringToIntsConverter>();
            CreateMap<string, AppealStatus>().ConvertUsing<StringToAppealStatus>();
            CreateMap<string, DriversLicenseType>().ConvertUsing<StringToDriversLicense>();
            CreateMap<string, AppealType>().ConvertUsing<StringToAppealType>();
        }
    }
}
