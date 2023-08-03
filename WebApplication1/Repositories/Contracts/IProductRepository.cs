using WebApplication1.DTOs.Products;
using WebApplication1.Utilities.Handlers;

namespace WebApplication1.Repositories.Contracts;

public interface IProductRepository : IGeneralRepository
{
    Task<ResponseHandler<IEnumerable<GetProductDto>>> Get();
}

