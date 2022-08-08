using AspNetAutofac.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetAutofac.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _productService.GetAllProductsAsync();
            if (result.Count > 0)
            {
                return Ok(result);
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllProductById(int id)
        {
            var result = await _productService.GetProductById(id);
            if (result !=null)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
    }
}