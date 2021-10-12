using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace MediatR.Cqrs.DI
{
    public static class ServiceCollectionExtentions
    {
        public static void AddMediatRCqrs(this IServiceCollection services, Type type)
        {
            services.AddMediatR(type);

            //services.AddValidatorsFromAssembly(typeof(Startup).Assembly);
            //services.AddMvcCore()
            //    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<GetAppealsQueryValidator>());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        }
    }
}
