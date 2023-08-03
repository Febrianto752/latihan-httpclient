using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repositories.Contracts;

namespace WebApplication1.Controllers;

public class ProductController : Controller
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var products = await _productRepository.Get();

        if (products == null)
        {
            TempData["Error"] = "data not found";

            return View();
        }

        Console.WriteLine("Berhasil");
        Console.WriteLine(products);

        foreach (var product in products.Data)
        {
            Console.WriteLine(product.Name);
            Console.WriteLine(product.Price);
        }

        return View(products.Data);
    }
}

