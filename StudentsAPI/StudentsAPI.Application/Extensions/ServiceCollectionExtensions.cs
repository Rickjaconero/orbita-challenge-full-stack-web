using Microsoft.Extensions.DependencyInjection;
using StudentsAPI.Application.Abstractions.Services;
using StudentsAPI.Service.Service;

namespace StudentsAPI.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ResolveApplicationDependencies(this IServiceCollection services)
        {
            services.AddScoped<IStudentsService, StudentsService>();

            return services;
        }
    }
}