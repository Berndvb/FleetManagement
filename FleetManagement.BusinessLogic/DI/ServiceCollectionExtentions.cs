using AutoMapper;
using FleetManagement.BLL.Features.Read.DriverManagement.GetAppeals;
using FleetManagement.BLL.Mapper.MapperSercice;
using FleetManagement.BLL.Mapper.Profiles;
using FleetManagement.BLL.Services;
using FleetManager.EFCore.DI;
using FluentValidation.AspNetCore;
using MediatR;
using MediatR.Cqrs;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FleetManagement.BLL.DI
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBLLServices(this IServiceCollection services)
        {
            services.AddMapper();
            services.AddEntityServices();
        }

        public static void AddMediatRCqrsServices(this IServiceCollection services)
        {
            services.AddMvc()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<GetAppealsForDriverQueryValidator>());
            services.AddMediatR(typeof(GetAppealsForDriverQuery).GetTypeInfo().Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        }

        public static void AddDALServices(this IServiceCollection services, string connectionString)
        {
            services.AddUnitOfWork();
            services.AddRepositories();
            services.AddDatabaseContext(connectionString);
        }

        #region mapper,- and entityservices
        public static void AddMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IMapperService, MapperService>();
        }

        public static void AddEntityServices(this IServiceCollection services)
        {
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<IAppealService, AppealService>();
            services.AddScoped<IDriverVehicleService, DriverVehicleService>();
            services.AddScoped<IFuelCardDriverService, FuelCardDriverService>();
            services.AddScoped<IFuelCardService, FuelCardService>();
            services.AddScoped<IMaintenanceService, MaintenanceService>();
            services.AddScoped<IRepareService, RepareService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IGeneralService, GeneralService>();
        }
        #endregion
    }
}
