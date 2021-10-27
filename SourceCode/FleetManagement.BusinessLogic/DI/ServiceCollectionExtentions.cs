using AutoMapper;
using FleetManagement.BLL.Features.DriverZone.GetAppealsForDriver;
using FleetManagement.BLL.Mapper.Profiles;
using FleetManagement.BLL.Services;
using FleetManager.EFCore.DI;
using FluentValidation.AspNetCore;
using MediatR;
using MediatR.Cqrs;
using Microsoft.Extensions.DependencyInjection;


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
            services.AddFluentValidation(config => {
                config.AutomaticValidationEnabled = false;
                config.RegisterValidatorsFromAssemblyContaining<GetAppealsForDriverQueryResult>();
            });
            services.AddMediatR(typeof(GetAppealsForDriverQueryResult).Assembly);
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
        }

        public static void AddEntityServices(this IServiceCollection services)
        {
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<IGeneralService, GeneralService>();
        }
        #endregion
    }
}
