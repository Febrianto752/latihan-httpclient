using API.DTOs.Products;
using API.Models;
using API.Services;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;

[ApiController]
[Route("api/v1/products")]
public class ProductController : ControllerBase
{
    private readonly ProductService _service;


    public ProductController(ProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        var products = _service.GetProducts();

        if (products == null)
        {
            return NotFound(new ResponseHandler<string>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data not found",
                Data = ""
            });
        }

        return Ok(new ResponseHandler<IEnumerable<GetProductDto>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Data found",
            Data = products
        });

    }

    [HttpPost]
    public IActionResult CreateProduct(CreateProductDto createProductDto)
    {
        var product = _service.CreateProduct(createProductDto);

        if (product == null)
        {
            return NotFound(new ResponseHandler<string>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data not found"
            });
        }

        return Ok(new ResponseHandler<Product>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Data found",
            Data = product
        });

    }
}

