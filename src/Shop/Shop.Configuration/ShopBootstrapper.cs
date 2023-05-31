using Common.Application.FileUtil;
using Common.Application.FileUtil.Interfaces;
using Common.Application.FileUtil.Services;
using Common.Application.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application._Utilities;
using Shop.Application.Users;
using Shop.Application.Users.Register;
using Shop.Facade;
using Shop.Infrastructure;

namespace Shop.Configuration
{
    public static class ShopBootstrapper
    {
        public static void RegisterShopDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterDependency(configuration);
            services.RegisterFacadeDependency();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));
            services.AddValidatorsFromAssembly(typeof(RegisterUserCommandValidator).Assembly);
            services.AddMediatR(typeof(FileValidation).Assembly);
            services.AddMediatR(typeof(Directories).Assembly);
        }
    }
}
