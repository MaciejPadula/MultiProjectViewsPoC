using ModularMonolithPoC.Infrastructure.Interfaces;
using ModularMonolithPoC.Infrastructure.Interfaces.Model;
using ModularMonolithPoC.ProductList.Models;

namespace ModularMonolithPoC.ProductList;

public interface IProductListService
{
    Task<List<ProductDto>> GetProducts(int page);
    Task<List<ProductDto>> GetTopProducts();
}

internal class ProductListService : IProductListService
{
    private readonly IProductRepository _productRepository;

    private const int PageSize = 10;
    private const int TopProductsCount = 3;

    public ProductListService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<ProductDto>> GetProducts(int page)
    {
        var products = await _productRepository.GetProducts(PageSize, page);
        return products
            .Where(p => p.Quantity > 0)
            .Select(MapToDto)
            .ToList();
    }

    public async Task<List<ProductDto>> GetTopProducts()
    {
        var topProducts = new List<ProductDto>();
        int page = 0;

        List<ProductEntity> products = [];
        do
        {
            products = await _productRepository.GetProducts(PageSize, page);
            var newTop = products
                .OrderBy(p => p.Quantity * p.Price)
                .Select(MapToDto)
                .Take(TopProductsCount);

            topProducts.AddRange(newTop);
            page += 1;
        }
        while (products.Count > 0);

        return topProducts
            .OrderBy(p => p.Price)
            .Take(TopProductsCount)
            .ToList();
    }

    private ProductDto MapToDto(ProductEntity product) =>
        new()
        {
            Name = product.Name,
            Description = product.Description,
            Price = product.Price
        };
}
