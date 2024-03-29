﻿using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = (await _productService.GetAllProducts()).Data;
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProduct(int productId)
        {
            var result = await _productService.GetProduct(productId);
            return Ok(result);
        }

        [HttpGet("category/{categoryUrl}")]
        public async Task<ActionResult<List<Product>>> GetProducts(string categoryUrl)
        {
            var products = (await _productService.GetProducts(categoryUrl)).Data;
            return Ok(products);
        }

        [HttpGet("search/{searchText}")]
        public async Task<ActionResult<List<Product>>> SearchProducts(string searchText)
        {
            var products = (await _productService.SearchProducts(searchText)).Data;
            return Ok(products);
        }

        [HttpGet("searchsuggestions/{searchText}")]
        public async Task<ActionResult<List<string>>> GetProductSearchSuggestions(string searchText)
        {
            var suggestions = (await _productService.GetProductSearchSuggestions(searchText)).Data;
            return Ok(suggestions);
        }
    }
}
