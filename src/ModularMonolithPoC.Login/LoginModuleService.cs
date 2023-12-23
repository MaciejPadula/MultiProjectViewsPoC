using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ModularMonolithPoC.Login;

public static class LoginModuleService
{
    public static IServiceCollection AddLoginModule(this IServiceCollection services)
    {
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<ILoginService, LoginService>();
        return services;
    }
}
