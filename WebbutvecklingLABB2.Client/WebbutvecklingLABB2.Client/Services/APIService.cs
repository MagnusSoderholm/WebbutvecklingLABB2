using System.Net.Http.Json;
using WebbutvecklingLABB2.Shared.Models;


namespace WebbutvecklingLABB2.Client.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<List<Product>> GetProductsAsync()
        {
            return _httpClient.GetFromJsonAsync<List<Product>>("api/products");
        }
    }
}
