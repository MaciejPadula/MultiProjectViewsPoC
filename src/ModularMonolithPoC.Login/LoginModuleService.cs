using Microsoft.Extensions.DependencyInjection;

namespace ModularMonolithPoC.Login;

public static class LoginModuleService
{
    public static IServiceCollection AddLoginModule(this IServiceCollection services)
    {
        services.AddScoped<ILoginService, LoginService>();
        return services;
    }
}
