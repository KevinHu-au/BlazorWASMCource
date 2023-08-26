namespace BlazorEcommerce.Server.Services.Products
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetAllProducts();
        Task<ServiceResponse<Product>> GetProduct(int productId);
    }
}
