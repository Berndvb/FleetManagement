﻿using FleetManagement.Domain.Interfaces;
using FleetManagement.EFCore.Infrastructure;
using FleetManager.EFCore.Repositories;
using FleetManager.EFCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


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
            services.AddScoped<IAppealRepository, AppealRepository>();
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<IReparationRepository, ReparationRepository>();
            services.AddScoped<IMaintenanceRepository, MaintenanceRepository>();
            services.AddScoped<IFuelCardRepository, FuelCardRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IDriverVehicleRepository, DriverVehicleRepository>();
            services.AddScoped<IIdentityVehicleRepository, IdentityVehicleRepository>();
        }

        public static void AddDatabaseContext(this IServiceCollection services) 
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);
            var configuration = builder.Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));
        }
    }
}