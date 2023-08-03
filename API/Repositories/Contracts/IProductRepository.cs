using API.Models;

namespace API.Repositories.Contracts;

public interface IProductRepository
{
    public IEnumerable<Product> GetAll();

    public Product Create(Product product);
}

