using Microsoft.Extensions.DependencyInjection;
using StudentsAPI.Data.Abstractions;
using StudentsAPI.Data.Abstractions.Repositories;
using StudentsAPI.Data.Repositories;

namespace StudentsAPI.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ResolveDataDependencies(this IServiceCollection services)
        {
            services.AddScoped<IApplicationContext, ApplicationContext>();
            services.AddScoped<IStudentsRepository, StudentsRepository>();

            return services;
        }
    }
}