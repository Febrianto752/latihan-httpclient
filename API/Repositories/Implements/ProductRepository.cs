using API.Data;
using API.Models;
using API.Repositories.Contracts;

namespace API.Repositories.Implements;

public class ProductRepository : IProductRepository
{
    protected readonly TestDbContext _context;

    public ProductRepository(TestDbContext context)
    {
        _context = context;
    }
    public Product Create(Product product)
    {
        try
        {
            _context.Set<Product>().Add(product);
            _context.SaveChanges();
            return product;
        }
        catch
        {
            return null;
        }
    }

    public IEnumerable<Product> GetAll()
    {
        return _context.Set<Product>().ToList();
    }
}

