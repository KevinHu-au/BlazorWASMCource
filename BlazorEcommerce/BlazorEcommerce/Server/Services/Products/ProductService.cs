﻿namespace BlazorEcommerce.Server.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Product>> GetProduct(int productId)
        {
            var response = new ServiceResponse<Product>();

            var product = await _context.Products
                                        .Include(p => p.Variants)
                                        .ThenInclude(v => v.ProductType)
                                        .FirstOrDefaultAsync(p => p.Id == productId);
            if (product == null) 
            {
                response.Success = false;
                response.Message = "Sorry, but this product does not exist";
            }
            else
            {
                response.Data = product;
            }
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetAllProducts()
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Data = await _context.Products.Include(p => p.Variants).ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProducts(string categoryUrl)
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Data = await _context.Products
                                     .Include(p => p.Variants)
                                     .Where(p => p.Category != null && p.Category.Url.ToLower().Equals(categoryUrl.ToLower()))
                                     .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<Product>>> SearchProducts(string searchText)
        {
            List<Product> products = await GetProductsWithSearchText(searchText);

            return new ServiceResponse<List<Product>> { Data = products };
        }

        public async Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText)
        {
            var result = new List<string>();
            List<Product> products  = await GetProductsWithSearchText(searchText);

            foreach (var product in products)
            {
                if (product.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(product.Title);
                }

                if (product.Description.IsNullOrEmpty())
                {
                    continue; 
                }

                var punctuations = product.Description.Where(c => char.IsPunctuation(c)).Distinct().ToArray();

                var words = product.Description.Split().Select(w => w.Trim(punctuations));
                foreach (var word in words) 
                {
                    if (!result.Contains(word))
                    {
                        result.Add(word); 
                    }
                }
            }

            return new ServiceResponse<List<string>> { Data = result };
        }
        private async Task<List<Product>> GetProductsWithSearchText(string searchText)
        {
            return await _context.Products
                .Where(p => (p.Title != null && p.Title.ToLower().Contains(searchText.ToLower())) ||
                            (p.Description != null && p.Description.ToLower().Contains(searchText.ToLower())))
                .ToListAsync();
        }
    }
}
