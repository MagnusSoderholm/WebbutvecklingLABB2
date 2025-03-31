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
            return await _httpClient.GetFromJsonAsync<List<Customer>>("api/customers");
        }
    }
}

