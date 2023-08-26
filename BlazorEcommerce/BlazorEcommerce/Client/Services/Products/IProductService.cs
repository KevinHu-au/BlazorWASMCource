namespace BlazorEcommerce.Client.Services.Products
{
    public interface IProductService
    {
        event Action OnProductsChanged;
        List<Product> Products { get; }
        Task GetProducts(string? categoryUrl = null);
        Task<ServiceResponse<Product>> GetProduct(int id);
    }
}
