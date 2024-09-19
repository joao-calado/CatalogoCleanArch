using CatalogoCleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoCleanArch.WebUI.Controllers;

public class ProductsController : Controller
{
    IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetProducts();
        return View(products);
    }
}
