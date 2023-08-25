namespace BlazorEcommerce.Client.Services.Products
{
    public interface IProductService
    {
        List<Product> Products { get; }
        Task GetProducts();
    }
}
