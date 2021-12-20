using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using PresentationApplication.Interfaces;

namespace PresentationPersistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<PresentationDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            services.AddScoped<IPresentationDbContext>(provider =>
            provider.GetService<PresentationDbContext>());
            return services;
        }
    }
}
