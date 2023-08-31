namespace BlazorEcommerce.Client.Services.Products
{
    public interface IProductService
    {
        event Action OnProductsChanged;
        string Message { get; set; }
        List<Product> Products { get; }
        Task GetProducts(string? categoryUrl = null);
        Task<ServiceResponse<Product>> GetProduct(int id);
        Task SearchProducts(string searchText);
        Task<List<string>> GetProductSearchSuggestions(string searchText);
    }
}
