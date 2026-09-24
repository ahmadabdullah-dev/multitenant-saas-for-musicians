using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITenantService, TenantService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IUserTenantService, UserTenantService>();

        services.Configure<EmailConfiguration>(configuration.GetSection("EmailConfiguration"));

        return services;
    }
}
