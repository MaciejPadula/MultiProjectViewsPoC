using Microsoft.Extensions.DependencyInjection;

namespace ModularMonolithPoC.ProductList;

public static class ProductListModule
{
    public static IServiceCollection AddProductListModule(this IServiceCollection services)
    {
        services.AddScoped<IProductListService, ProductListService>();
        return services;
    }
}
