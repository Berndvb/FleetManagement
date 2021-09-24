using FleetManagement.Domain.Interfaces;
using FleetManager.EFCore.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace FleetManagement.BLL
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataAccessServices(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
