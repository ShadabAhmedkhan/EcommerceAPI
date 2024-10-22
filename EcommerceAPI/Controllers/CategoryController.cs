using EcommerceAPI.Converter;
using EcommerceAPI.DTO;
using EcommerceAPI.Model;
using EcommerceAPI.Repository;
using EcommerceAPI.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory<Category> _categoryRepository;

        public CategoryController(ICategory<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Getcategorys()
        {
            var category = await _categoryRepository.GetAll();
            return Ok(category);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Getcategory(int id)
        {
            var category = await _categoryRepository.GetById(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Createcategory(CategoryDTO category)
        {
            
            await _categoryRepository.Add(CategoryConverter.Category(category));
            await _categoryRepository.Save();
            return CreatedAtAction(nameof(Getcategory), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Updatecategory(int id, CategoryDTO category)
        {
            if (id != category.Id) return BadRequest();

            _categoryRepository.Update(CategoryConverter.Category(category));
            await _categoryRepository.Save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecategory(int id)
        {
            var category = await _categoryRepository.GetById(id);
            if (category == null) return NotFound();

            _categoryRepository.Delete(category);
            await _categoryRepository.Save();
            return NoContent();
        }
    }
}
