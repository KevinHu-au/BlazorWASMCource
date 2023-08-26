using System.Net.Http.Json;

namespace BlazorEcommerce.Client.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<Category> Categories { get; private set; } = new List<Category>();

        public async Task GetAllCategories()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/Categories");
            if (response != null && response.Data != null) 
            {
                Categories = response.Data;
            }
        }
    }
}
