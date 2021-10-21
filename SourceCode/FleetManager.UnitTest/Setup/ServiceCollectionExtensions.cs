﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FleetManager.UnitTest.Http;

namespace FleetManager.UnitTest.Integration.Setup
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Removes all registered <see cref="ServiceLifetime.Transient"/> registrations of <see cref="TService"/> and adds a new registration which uses the <see cref="Func{IServiceProvider, TService}"/>.
        /// </summary>
        /// <typeparam name="TService">The type of service interface which needs to be placed.</typeparam>
        /// <param name="services"></param>
        /// <param name="implementationFactory">The implementation factory for the specified type.</param>
        public static void SwapTransient<TService>(
            this IServiceCollection services,
            Func<IServiceProvider, TService> implementationFactory)
        {
            if (services.Any(x => x.ServiceType == typeof(TService) && x.Lifetime == ServiceLifetime.Transient))
            {
                var serviceDescriptors = services
                    .Where(x => x.ServiceType == typeof(TService) && x.Lifetime == ServiceLifetime.Transient).ToList();
                foreach (var serviceDescriptor in serviceDescriptors)
                    services.Remove(serviceDescriptor);
            }

            services.AddTransient(typeof(TService), (
                sp) => implementationFactory(sp));
        }
    }
}
