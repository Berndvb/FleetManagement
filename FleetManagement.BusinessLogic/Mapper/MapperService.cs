using AutoMapper;
using FleetManagement.Domain.Models;
using FleetManagement.Framework.Models.Dtos;
using FleetManagement.Framework.Models.Dtos.ShowDtos;

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

            //GetAppealInfoForDriver - !!!
            CreateMap<Driver, AppealDto>()// How to include proportie from a List<obj>
                .IncludeMembers(x => x.Appeals, y => y.Vehicles, z => z.Vehicles.Identity);
            CreateMap<Appeal, AppealDto>()
                .IncludeMembers(x => x.Vehicle, y => y.Vehicle.Identity);
            CreateMap<Vehicle, VehicleOverviewDto>()
                .IncludeMembers(x => x.Identity);

            //GetFuelCardsDetailsForDriver (via FuelCards DbSet and not Driver) - !!!
            CreateMap<FuelCard, FuelCardDto>()
                .IncludeMembers(x => x.FuelCardOptions, y => y.Drivers);

            //GetAppealsForDriverPerCar
            CreateMap<Driver, VehicleAppealDto>()
                .IncludeMembers(x => x.Appeals);
            CreateMap<Appeal, VehicleAppealDto>();

            //GetVehicleDetailsForDriver - can this be simpler?
            CreateMap<DriverVehicle, IdentityVehicleDto>()
                .IncludeMembers(x => x.Vehicle, y => y.Vehicle.Identity);
            CreateMap<DriverVehicle, DriverVehicleDto>();

            //GetMaintenancesForDriverPerCar
            CreateMap<Maintenance, VehicleMaintenanceDto>();

            //GetReparationsForDriverPerCar
            CreateMap<Repare, VehicleRepareDto>();
        }
    }
}
