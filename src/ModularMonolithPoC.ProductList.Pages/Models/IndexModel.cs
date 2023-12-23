using ModularMonolithPoC.ProductList.Models;

namespace ModularMonolithPoC.ProductList.Pages.Models;

internal class IndexModel
{
    public required List<ProductDto> Products { get; set; }
    public required List<ProductDto> TopProducts { get; set; }
}
