using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using POS_API.Authorization;
using POS_API.Helpers;
using POS_API.Models.Categories;
using POS_API.Models.Users;
using POS_API.Services;

namespace POS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;
        private IMapper _mapper;

        public CategoryController(
            ICategoryService categoryService,
            IMapper mapper
        ){
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _categoryService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _categoryService.GetById(id);
            return Ok(user);
        }
        [HttpPost]
        public IActionResult Create(CategoryRequest model)
        {
            var response = _categoryService.create(model);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateCategory model)
        {
            _categoryService.Update(id, model);
            return Ok(new { message = "Category updated successfully" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return Ok(new { message = "Category deleted successfully" });
        }
    }
}
