namespace BlazorEcommerce.Client.Services.Categories
{
    public interface ICategoryService
    {
        List<Category> Categories { get; }
        Task GetAllCategories();
    }
}
