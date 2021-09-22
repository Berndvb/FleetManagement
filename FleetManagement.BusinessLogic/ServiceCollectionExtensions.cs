using FleetManagement.Domain.Interfaces;
using FleetManagement.EFCore.Infrastructure;
using FleetManager.Dapper.Infrastructure;
using FleetManager.Domain.Interfaces;
using FleetManager.EFCore.Repositories;
using FleetManager.EFCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;
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
