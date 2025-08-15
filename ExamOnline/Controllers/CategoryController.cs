using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
            {
                return BadRequest("Category cannot be null.");
            }
            var createdCategory = await categoryService.CreateCategoryAsync(categoryDTO);
            return CreatedAtAction(nameof(GetCategoryById), new { id = createdCategory.CategoryId }, createdCategory);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
            {
                return BadRequest("Category ID mismatch or null category.");
            }
            var updatedCategory = await categoryService.UpdateCategoryAsync(id, categoryDTO);
            if (updatedCategory == null)
            {
                return NotFound();
            }
            return Ok(updatedCategory);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await categoryService.DeleteCategoryAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
