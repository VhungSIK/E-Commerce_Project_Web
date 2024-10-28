using Microsoft.AspNetCore.Mvc;
using fbwa_web.Data;
using fbwa_web.Models;
using System.Linq;

namespace fbwa_web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly FBWAContext _context;

        public ProductController(FBWAContext context)
        {
            _context = context;
        }

        // GET: api/product
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }

        // GET: api/product/{id}
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        // POST: api/product
        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            if (product == null) return BadRequest();
            _context.Products.Add(product);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductID }, product);
        }

        // PUT: api/product/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            if (id != updatedProduct.ProductID) return BadRequest();
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();

            product.ProductName = updatedProduct.ProductName;
            product.Description = updatedProduct.Description;
            product.Price = updatedProduct.Price;
            product.StockQuantity = updatedProduct.StockQuantity;
            product.SKU = updatedProduct.SKU;
            product.IsActive = updatedProduct.IsActive;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/product/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();
            _context.Products.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
