using AutoMapper;
using FleetManagement.BLL.Services;
using FleetManagement.Domain.Interfaces;
using FleetManagement.EFCore.Infrastructure;
using FleetManager.Domain.Interfaces;
using FleetManager.EFCore.Repositories;
using FleetManager.EFCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace FleetManagement.BLL.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }

        public static void AddDatabaseContext(this IServiceCollection services)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);
            var configuration = builder.Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));
        }

        public static void AddMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void AddMediatRCqs(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddMediatR(assemblies);
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
        }
    }
}
