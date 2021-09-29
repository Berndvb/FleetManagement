using AutoMapper;
using FleetManagement.BLL.Services;
using FleetManagement.Domain.Interfaces;
using FleetManagement.Domain.Models;
using FleetManagement.EFCore.Infrastructure;
using FleetManager.Dapper.Repositories;
using FleetManager.Domain.Interfaces;
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
            services.AddScoped(typeof(IGenericRepository<Appeal>), typeof(GenericRepository<Appeal>));
            services.AddScoped(typeof(IGenericRepository<Driver>), typeof(GenericRepository<Driver>));
            services.AddScoped(typeof(IGenericRepository<Repare>), typeof(GenericRepository<Repare>));
            services.AddScoped(typeof(IGenericRepository<Maintenance>), typeof(GenericRepository<Maintenance>));
            services.AddScoped(typeof(IGenericRepository<FuelCard>), typeof(GenericRepository<FuelCard>));
            services.AddScoped(typeof(IGenericRepository<Vehicle>), typeof(GenericRepository<Vehicle>));
            services.AddScoped(typeof(IGenericRepository<DriverVehicle>), typeof(GenericRepository<DriverVehicle>));
            services.AddScoped(typeof(IGenericRepository<IdentityVehicle>), typeof(GenericRepository<IdentityVehicle>));
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
                mc.AddProfile(new MapperService());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
