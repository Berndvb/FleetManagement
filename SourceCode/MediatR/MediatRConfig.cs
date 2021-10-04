using Microsoft.Extensions.DependencyInjection;

namespace MediatR.Cqs
{
    public static class MediatRConfig
    {
        public static void ConfigureMediatR(this IServiceCollection services)
        {
            services.AddMediatR(typeof(MediatRConfig).Assembly);
        }
    }
}
