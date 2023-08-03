using System.Net.Http.Headers;
using WebApplication1.Repositories.Contracts;

namespace WebApplication1.Repositories.Implements;

public class GeneralRepository : IGeneralRepository
{
    protected readonly string request;
    protected readonly HttpClient httpClient;
    protected readonly IHttpContextAccessor contextAccessor;

    public GeneralRepository(string request)
    {
        this.request = request;
        contextAccessor = new HttpContextAccessor();

        httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7027/api/v1/")
        };

        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", contextAccessor.HttpContext?.Session.GetString("JWToken"));
    }
}

