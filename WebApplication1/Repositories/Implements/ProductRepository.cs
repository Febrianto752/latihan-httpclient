
using Newtonsoft.Json;
using System.Text;
using WebApplication1.DTOs.Products;
using WebApplication1.Repositories.Contracts;
using WebApplication1.Utilities.Handlers;

namespace WebApplication1.Repositories.Implements;

public class ProductRepository : GeneralRepository, IProductRepository
{
    public ProductRepository(string request = "products/") : base(request)
    {
    }
    public async Task<ResponseHandler<IEnumerable<GetProductDto>>> Get()
    {
        ResponseHandler<IEnumerable<GetProductDto>> entityVM = null;
        using (var response = await httpClient.GetAsync(request))
        {
            Console.WriteLine($"response : {response}");
            Console.WriteLine($"response isSuccess : {response.IsSuccessStatusCode}");

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();

                entityVM = JsonConvert.DeserializeObject<ResponseHandler<IEnumerable<GetProductDto>>>(apiResponse);

            }
            else
            {
                entityVM = new ResponseHandler<IEnumerable<GetProductDto>> { Code = (int)response.StatusCode, Message = response.ReasonPhrase };
            }


        }
        return entityVM;
    }

    public async Task<ResponseHandler<GetProductDto>> Post(CreateProductDto entity)
    {
        ResponseHandler<GetProductDto> entityVM = null;
        StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
        using (var response = httpClient.PostAsync(request, content).Result)
        {
            Console.WriteLine($"response : {response}");
            Console.WriteLine($"response isSuccess : {response.IsSuccessStatusCode}");

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();

                entityVM = JsonConvert.DeserializeObject<ResponseHandler<GetProductDto>>(apiResponse);

            }
            else
            {
                entityVM = new ResponseHandler<GetProductDto> { Code = (int)response.StatusCode, Message = response.ReasonPhrase };
            }
        }
        return entityVM;
    }
}

