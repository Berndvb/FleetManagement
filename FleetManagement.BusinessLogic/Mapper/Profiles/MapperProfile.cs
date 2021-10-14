using System.Collections.Generic;
using AutoMapper;
using FleetManagement.BLL.Mapper.Converters;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManagement.BLL.Models.Dtos.WriteDtos;
using FleetManagement.Domain.Models;
using FleetManagement.Framework.Models.Enums;

namespace FleetManagement.BLL.Mapper.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
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

            CreateMap<Driver, AddDriverDetailsDto>();

            CreateMap<AddDriverVehicleDto, DriverVehicle>();

            CreateMap<AddFuelCardDriverDto, FuelCardDriver>();

            CreateMap<AddFuelCardOptionsDto, FuelCardOptions>();

            CreateMap<AddDriverDetailsDto, Driver>();

            CreateMap<UpdateDriverDetailsDto, Driver>();

            CreateMap<AddIdentityPersonDto, IdentityPerson>();

            CreateMap<AddContactInfoDto, ContactInfo>();

            CreateMap<AddAddressDto, Address>();

            CreateMap<AddFuelCardDto, FuelCard>();

            CreateMap<AddVehicleDetailsDto, Vehicle>()
                .ForMember(x => x.Mileage, y => y.MapFrom(z => z.Mileage.ToString()));

            CreateMap<AddIdentityVehicleDto, IdentityVehicle>();

            //Extra convertingmaps
            CreateMap<string, List<string>>().ConvertUsing<StringToStringsConverter>();
            CreateMap<string, List<int>>().ConvertUsing<StringToIntsConverter>();
            CreateMap<string, AppealStatus>().ConvertUsing<StringToAppealStatus>();
            CreateMap<string, DriversLicenseType>().ConvertUsing<StringToDriversLicense>();
        }
    }
}
