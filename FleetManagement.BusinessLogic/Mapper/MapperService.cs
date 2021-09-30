using AutoMapper;
using FleetManagement.BLL.Mapper.Converters;
using FleetManagement.Domain.Models;
using FleetManagement.Framework.Models.Dtos;
using FleetManagement.Framework.Models.Dtos.ShowDtos;
using System.Collections.Generic;

namespace FleetManagement.BLL.Services
{
    public class MapperService : Profile
    {
        public MapperService() 
        {
            //GetAllDriverOverviews
            CreateMap<Driver, DriverOverviewDto>()
                .IncludeMembers(x => x.Identity);

            //GetDriverDetails
            CreateMap<Driver, DriverDetailsDto>()
                .IncludeMembers(x => x.Identity, y => y.Contactinfo, z => z.Contactinfo.Address);

            CreateMap<IdentityPerson, IdentityPersonDto>();
            CreateMap<ContactInfo, ContactInfoDto>()
             .IncludeMembers(x => x.Address);
            CreateMap<Address, AddressDto>();

            // !!! -  GetAppealInfoForDriver 
            CreateMap<Driver, AppealDto>()// but how to include proportie from a List<obj>
                .IncludeMembers(x => x.Appeals, y => y.Vehicles, z => z.Vehicles.Identity);
            CreateMap<Appeal, AppealDto>()
                .IncludeMembers(x => x.Vehicle, y => y.Vehicle.Identity); //we exclude the Driver-property
            CreateMap<Vehicle, VehicleOverviewDto>()
                .IncludeMembers(x => x.Identity);

            CreateMap<Appeal, AppealDto>() // Alternatively  via Appeals itself and not Driver (bigger query though...)
                .IncludeMembers(x => x.Vehicle, y => y.Vehicle.Identity);
            CreateMap<FuelCardOptions, FuelCardOptionsDto>();
            CreateMap<Vehicle, VehicleOverviewDto>()
                .IncludeMembers(x => x.Identity);

            // !!! -  GetFuelCardsDetailsForDriver
            CreateMap<Driver, FuelCardDto>() //via Driver: but how to include proportie from a List<obj>
                .IncludeMembers(x => x.FuelCards, y => y.FuelCards.FuelCard, z => z.FuelCards.FuelCard.FuelCardOptions);

            CreateMap<FuelCard, FuelCardDto>() // Alternatively  via FuelCards itself and not Driver (bigger query though...)
           .IncludeMembers(x => x.FuelCardOptions);
            CreateMap<FuelCardOptions, FuelCardOptionsDto>();

            //GetAppealsForDriverPerCar
            CreateMap<Driver, VehicleAppealDto>()
                .IncludeMembers(x => x.Appeals);
            CreateMap<Appeal, VehicleAppealDto>();

            //GetVehicleDetailsForDriver
            CreateMap<DriverVehicle, VehicleDetailsDto>()
                .IncludeMembers(x => x.Vehicle, y => y.Vehicle.Identity);
            CreateMap<IdentityVehicle, IdentityVehicleDto>();
            CreateMap<DriverVehicle, DriverVehicleDto>();

            //GetMaintenancesForDriverPerCar
            CreateMap<Maintenance, VehicleMaintenanceDto>();

            //GetReparationsForDriverPerCar
            CreateMap<Repare, VehicleRepareDto>();

            //Extra convertingmaps
            CreateMap<string, List<string>>().ConvertUsing<StringToStringsConverter>();
            CreateMap<string, List<int>>().ConvertUsing<StringToIntsConverter>();

        }
    }
}
