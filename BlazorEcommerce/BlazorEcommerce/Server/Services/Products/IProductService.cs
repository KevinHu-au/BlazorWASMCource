namespace BlazorEcommerce.Server.Services.Products
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProducts();
        Task<ServiceResponse<Product>> GetProduct(int productId);
    }
}
