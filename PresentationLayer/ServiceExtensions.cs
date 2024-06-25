using BusinessLogicLayer.Builders;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DataAccessLayer.Repositories;

namespace PresentationLayer;

public static class ServiceExtensions
{
    public static void AddScopeServices(this IServiceCollection services)
    {
        //repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProfileRepository, ProfileRepository>();
        services.AddScoped<IDocumentRepository, DocumentRepository>();
        //services
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IProfileService, ProfileService>();
        services.AddScoped<IDocumentService, DocumentService>();    
        //builders
        services.AddScoped<IUserBuilder, UserBuilder>();
        services.AddScoped<IProfileBuilder, ProfileBuilder>();
        services.AddScoped<IDocumentBuilder, DocumentBuilder>();
    }
    public static void AddSingletonServices(this IServiceCollection services)
    {
        
    }

    public static void AddTransientServices(this IServiceCollection services)
    {
        
    }
}