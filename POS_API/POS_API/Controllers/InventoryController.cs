using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS_API.Authorization;
using POS_API.Models.Categories;
using POS_API.Models.Inventories;
using POS_API.Services;

namespace POS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InventoryController : ControllerBase
    {
        private IInventoryService _inventoryService;
        private IMapper _mapper;

        public InventoryController(
            IInventoryService inventoryService,
            IMapper mapper
        )
        {
            _inventoryService = inventoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _inventoryService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _inventoryService.GetById(id);
            return Ok(user);
        }
        [HttpPost]
        public IActionResult Create(InventoryRequest model)
        {
            var response = _inventoryService.create(model);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateInventory model)
        {
            _inventoryService.Update(id, model);
            return Ok(new { message = "Category updated successfully" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _inventoryService.Delete(id);
            return Ok(new { message = "Category deleted successfully" });
        }
    }
}
