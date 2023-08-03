using API.Data;
using API.DTOs.Products;
using API.Models;
using API.Repositories.Contracts;

namespace API.Services;

public class ProductService
{
    private readonly TestDbContext _context;
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository, TestDbContext testDbContext)
    {
        _productRepository = productRepository;
        _context = testDbContext;
    }

    public List<GetProductDto>? GetProducts()
    {
        var getProducts = _productRepository.GetAll().ToList();

        if (getProducts == null)
        {
            return null;
        }

        var products = getProducts.Select(p => new GetProductDto
        {
            Guid = p.Guid,
            Name = p.Name,
            Price = p.Price,
            CreatedDate = p.CreatedDate,
            ModifiedDate = p.ModifiedDate

        }).ToList();

        return products;
    }

    public Product? CreateProduct(CreateProductDto product)
    {
        var newProduct = new Product
        {
            Guid = new Guid(),
            Name = product.Name,
            Price = product.Price,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now,
        };
        var createdProduct = _productRepository.Create(newProduct);

        if (createdProduct == null)
        {
            return null;
        }

        return createdProduct;
    }
}

