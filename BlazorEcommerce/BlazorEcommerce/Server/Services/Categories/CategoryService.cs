namespace BlazorEcommerce.Server.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _dataContext;

        public CategoryService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<ServiceResponse<List<Category>>> GetAllCategories()
        {
            var categories = await _dataContext.Categories.ToListAsync();
            return new ServiceResponse<List<Category>>()
            {
                Data = categories
            };
        }
    }
}
