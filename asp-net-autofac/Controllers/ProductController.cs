using AspNetAutofac.API.Models;
using AspNetAutofac.API.Services;
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
            return NotFound(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllProductById(int id)
        {
            var result = await _productService.GetProductById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            var result = await _productService.AddProduct(product);
            if (result)
            {
                return Ok(product);
            }
            return BadRequest(result);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromQuery] int id, [FromBody] Product product)
        {
            var result = await _productService.UpdateProduct(id, product);
            if (result)
            {
                return Ok(product);
            }
            return BadRequest(result);
        }
    }
}