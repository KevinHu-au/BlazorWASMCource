namespace BlazorEcommerce.Server.Services.Products
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProducts();
    }
}
