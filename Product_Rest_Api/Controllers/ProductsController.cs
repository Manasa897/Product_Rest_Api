using Microsoft.AspNetCore.Mvc;
using Product_Rest_Api.Models;
using Product_Rest_Api.Repositories;

namespace Product_Rest_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productRepository.GetAllProducts();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            var newproduct = await _productRepository.AddProduct(product);
            return CreatedAtAction(nameof(GetProduct), new { id = newproduct.Id }, newproduct);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product) 
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            await _productRepository.UpdateProduct(product);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteProduct(int id)
        {
            await _productRepository.DeleteProduct(id);
            return NoContent();
        }
      
    }
}
