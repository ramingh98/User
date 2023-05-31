using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shop.Facade.Users;


namespace Shop.Facade
{
    public static class FacadeBootstrapper
    {
        public static IServiceCollection RegisterFacadeDependency(this IServiceCollection services)
        {
            services.AddTransient<IUserFacade, UserFacade>();
            services.AddMediatR(typeof(IUserFacade).Assembly);
            return services;
        }
    }
}
