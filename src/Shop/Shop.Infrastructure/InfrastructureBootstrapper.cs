using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Infrastructure._Utilities.MediatR;
using Shop.Infrastructure.Persistent;
using Shop.Infrastructure.Persistent.Users;

namespace Shop.Infrastructure
{
    public static class InfrastructureBootstrapper
    {
        public static IServiceCollection RegisterDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ICustomPublisher, CustomPublisher>();
            services.AddDbContext<AppDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("App_Context")));
            return services;
        }
    }
}
