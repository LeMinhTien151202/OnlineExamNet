using ExamOnline.Exceptions;
using ExamOnline.Interfaces.ICategory;
using Microsoft.AspNetCore.Authorization;
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
                throw new NotFoundException($"Category {id} not found");
            }
            return Ok(category);
        }
        [HttpPost]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
            {
                throw new BadRequestException("Invalid category data");
            }
            var createdCategory = await categoryService.CreateCategoryAsync(categoryDTO);
            return Ok(createdCategory);
        }
        [HttpPut("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
            {
                throw new BadRequestException("Category ID mismatch or null category.");
            }
            var updatedCategory = await categoryService.UpdateCategoryAsync(id, categoryDTO);
            if (updatedCategory == null)
            {
                throw new NotFoundException($"Category {id} not found");
            }
            return Ok(updatedCategory);
        }
        [HttpDelete("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await categoryService.DeleteCategoryAsync(id);
            if (!result)
            {
                throw new NotFoundException($"Category {id} not found");
            }
            return NoContent();
        }
    }
}
