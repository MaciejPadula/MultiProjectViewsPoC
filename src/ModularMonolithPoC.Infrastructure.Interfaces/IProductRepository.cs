using ModularMonolithPoC.Infrastructure.Interfaces.Model;

namespace ModularMonolithPoC.Infrastructure.Interfaces;

public interface IProductRepository
{
    Task<List<ProductEntity>> GetProducts(int pageSize, int pageNumber);
}
