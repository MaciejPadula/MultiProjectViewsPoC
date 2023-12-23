using Microsoft.AspNetCore.Mvc;
using ModularMonolithPoC.ProductList.Pages.Models;

namespace ModularMonolithPoC.ProductList.Pages;

public class ProductListController : Controller
{
    private readonly IProductListService _productListService;

    public ProductListController(IProductListService productListService)
    {
        _productListService = productListService;
    }

    public async Task<IActionResult> Index(int page = 0)
    {
        var products = await _productListService.GetProducts(page);
        var topProducts = await _productListService.GetTopProducts();
        var model = new IndexModel
        {
            Products = products,
            TopProducts = topProducts
        };

        return View(model);
    }
}
