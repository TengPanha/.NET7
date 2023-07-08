using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS_API.Authorization;
using POS_API.Models.Products;
using POS_API.Services;

namespace POS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetAll();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);
            return Ok(product);
        }
        [HttpPost]
        public IActionResult Create([FromBody]ProductRequest model)
        {
            var product = _productService.create(model);
            return Ok(product);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UpdateProduct model)
        {
            _productService.Update(id, model);
            return Ok(new { message = "Product updated successfully" });
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return Ok(new { message = "Product deleted successfully" });
        }
        
    }
}
