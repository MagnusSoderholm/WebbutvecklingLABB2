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

        public async Task AddProductAsync(Product product)
        {
            var response = await _httpClient.PostAsJsonAsync("api/products", product);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateProductAsync(Product product)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/products/{product.Id}", product);
            response.EnsureSuccessStatusCode();
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            var response = await _httpClient.PostAsJsonAsync("api/customers", customer);
            response.EnsureSuccessStatusCode();
        }
        public async Task<bool> DeleteCustomerAsync(int customerId)
        {
            var response = await _httpClient.DeleteAsync($"api/customers/{customerId}");
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            var response = await _httpClient.DeleteAsync($"api/products/{productId}");
            return response.IsSuccessStatusCode;
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