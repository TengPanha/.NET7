using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS_API.Authorization;
using POS_API.Models.Categories;
using POS_API.Models.Customers;
using POS_API.Services;

namespace POS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;
        private IMapper _mapper;

        public CustomerController(
            ICustomerService customerService,
            IMapper mapper
        )
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _customerService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _customerService.GetById(id);
            return Ok(user);
        }
        [HttpPost]
        public IActionResult Create(CustomerRequest model)
        {
            var response = _customerService.create(model);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateCustomer model)
        {
            _customerService.Update(id, model);
            return Ok(new { message = "Category updated successfully" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _customerService.Delete(id);
            return Ok(new { message = "Category deleted successfully" });
        }
    }
}
