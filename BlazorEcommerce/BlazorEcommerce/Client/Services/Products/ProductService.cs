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

        public async Task GetProducts()
        {
            var products = await _httpClient.GetFromJsonAsync<List<Product>>("api/Products");
            if (products != null) 
            {
                Products = products;
            }
        }
    }
}
