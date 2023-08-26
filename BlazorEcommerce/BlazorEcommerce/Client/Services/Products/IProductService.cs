namespace BlazorEcommerce.Client.Services.Products
{
    public interface IProductService
    {
        List<Product> Products { get; }
        Task LoadAllProducts();
        Task<ServiceResponse<Product>> GetProduct(int id);
    }
}
