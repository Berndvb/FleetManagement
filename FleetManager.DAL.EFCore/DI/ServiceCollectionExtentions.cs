using FleetManagement.Domain.Interfaces.Repositories;
using FleetManagement.EFCore.Infrastructure;
using FleetManager.Domain.Interfaces.Repositories;
using FleetManager.EFCore.Repositories;
using FleetManager.EFCore.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FleetManager.EFCore.DI
{
    public static class ServiceCollectionExtentions
    {
        public static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }

        public static void AddDatabaseContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
