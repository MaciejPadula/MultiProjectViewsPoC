using ModularMonolithPoC.Infrastructure.Interfaces;
using ModularMonolithPoC.Infrastructure.Interfaces.Model;

namespace ModularMonolithPoC.Infrastructure;

internal class MockProductRepository : IProductRepository
{
    private readonly List<ProductEntity> _products = [
        new ProductEntity
        {
            Id = 1,
            Name = "Łyżka",
            Description = "Description 1",
            Price = 12,
            Quantity = 10
        },
        new ProductEntity
        {
            Id = 2,
            Name = "Mleko",
            Description = "Description 2",
            Price = 6,
            Quantity = 20
        },
        new ProductEntity
        {
            Id = 3,
            Name = "Piwo",
            Description = "Description 3",
            Price = 4.5m,
            Quantity = 30
        },
    ];

    public async Task<List<ProductEntity>> GetProducts(int pageSize, int pageNumber)
    {
        return _products
            .Skip(pageNumber * pageSize)
            .Take(pageSize)
            .ToList();
    }
}
