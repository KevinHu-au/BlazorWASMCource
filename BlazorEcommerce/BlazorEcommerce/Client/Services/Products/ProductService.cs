using System.Net.Http.Json;

namespace BlazorEcommerce.Client.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<Product> Products { get; private set; } = new List<Product>();

        public async Task<ServiceResponse<Product>> GetProduct(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<Product>>($"api/Products/{id}");
            if (response == null)
                response = new ServiceResponse<Product> { Success = false, Message = "Cannot get the product. Please try again." };
            return response;
        }

        public async Task LoadAllProducts()
        {
            var products = await _httpClient.GetFromJsonAsync<List<Product>>("api/Products");
            if (products != null) 
            {
                Products = products;
            }
        }
    }
}
