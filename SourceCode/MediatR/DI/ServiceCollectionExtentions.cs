using Microsoft.Extensions.DependencyInjection;
using System;

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
