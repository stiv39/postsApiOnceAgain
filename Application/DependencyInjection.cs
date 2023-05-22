using Application.Mapping;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;


            services.AddAutoMapper(typeof(MappingProfile));
            services.AddMediatR(assembly);

            return services;
        }
    }
}
