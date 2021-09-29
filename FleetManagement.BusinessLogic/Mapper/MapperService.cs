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
            //Driver
            CreateMap<Driver, DriverOverviewDto>()
                .IncludeMembers(x => x.Identity.Name)
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Identity.Name));

            CreateMap<Driver, DriverDetailsDto>()
                .IncludeMembers(x => x.Identity)
                .IncludeMembers(x => x.Contactinfo)
                .IncludeMembers(x => x.Contactinfo.Address);

            //IdentityVehicle
            CreateMap<IdentityVehicle, IdentityVehicleDto>();
            // These two are combined into vehiceDetailsDto -> can be more efficient
            //DriverVehicle
            CreateMap<DriverVehicle, DriverVehicleDto>();

            //Repare
            CreateMap<Repare, VehicleRepareDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.InvoiceDate, y => y.MapFrom(z => z.InvoiceDate));

            //Maintenance
            CreateMap<Maintenance, VehicleMaintenanceDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.InvoiceDate, y => y.MapFrom(z => z.InvoiceDate));

            //Appeal
            CreateMap<Driver, VehicleAppealDto>()
                .IncludeMembers(x => x.Appeals); 

            CreateMap<Appeal, AppealDto>()
                .IncludeMembers(x => x.Vehicle)
                .IncludeMembers(x => x.Vehicle.Identity);

            //FuelCard
            CreateMap<Driver, FuelCardDto>()
                .IncludeMembers(x => x.FuelCards)
                .IncludeMembers(x => x.FuelCards)
                .IncludeMembers(x => x.Appeals); // still need FuelCard-class in fuelcards + fuelcardoptions
        }
    }
}
