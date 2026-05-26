using UsersService.Core.ServiceContracts;
using UsersService.Core.Services;
using UsersService.Core.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace UsersService.Core;

public static class DependencyInjection
{
    /// <summary>
    /// Registers the core services with the dependency injection container.
    /// </summary> <param name="services">The service collection to add the services to.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
        return services;
    }
}
