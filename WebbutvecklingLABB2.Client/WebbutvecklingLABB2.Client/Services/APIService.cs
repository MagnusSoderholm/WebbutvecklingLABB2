//using System.Net.Http.Json;
//using WebbutvecklingLABB2.Shared.Models;


//namespace WebbutvecklingLABB2.Client.Services
//{
//    public class ApiService
//    {
//        private readonly HttpClient _httpClient;

//        public ApiService(HttpClient httpClient)
//        {
//            _httpClient = httpClient;
//        }

//        public Task<List<Product>> GetProductsAsync()
//        {
//            return _httpClient.GetFromJsonAsync<List<Product>>("api/products");
//        }
//    }
//}

using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Product>>("api/products");
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/customers");
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"API Response: {content}");
                return await response.Content.ReadFromJsonAsync<List<Customer>>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching customers: {ex.Message}");
                return null;
            }
        }
    }
}

