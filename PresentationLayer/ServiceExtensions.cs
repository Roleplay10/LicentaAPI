using BusinessLogicLayer.Builders;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DataAccessLayer.Repositories;

namespace PresentationLayer;

public static class ServiceExtensions
{
    public static void AddScopeServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserBuilder, UserBuilder>();
    }
    public static void AddSingletonServices(this IServiceCollection services)
    {
        
    }

    public static void AddTransientServices(this IServiceCollection services)
    {
        
    }
}