using UsersService.Core.RepositoryContracts;
using UsersService.Infrastructure.DbContext;
using UsersService.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace UsersService.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    /// Registers the infrastructure services with the dependency injection container.
    /// </summary> <param name="services">The service collection to add the services to.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<DapperDbContext>();
        return services;
    }
}
