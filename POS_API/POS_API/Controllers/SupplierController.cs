using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS_API.Authorization;
using POS_API.Models.Suppliers;
using POS_API.Services;

namespace POS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SupplierController : ControllerBase
    {
        private ISuppliersService _supplierService;
        public SupplierController(ISuppliersService supplierService)
        {
            _supplierService = supplierService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var suppliers = _supplierService.GetAll();
            return Ok(suppliers);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var supplier = _supplierService.GetById(id);
            return Ok(supplier);
        }
        [HttpPost]
        public IActionResult Create([FromBody]SupplierRequest model)
        {
            var supplier = _supplierService.create(model);
            return Ok(supplier);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UpdateSupplier model)
        {
            _supplierService.Update(id, model);
            return Ok(new { message = "Supplier update successfully" });
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _supplierService.Delete(id);
            return Ok(new { message = "Supplier deleted successfully" });
        }   
    }
}
