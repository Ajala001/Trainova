using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trainova.Infrastructure.Database;

namespace Trainova.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TrainovaDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Database")));

            return services;
        }
    }
}
