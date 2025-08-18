
using ExamOnline.Interfaces.ICategory;

namespace ExamOnline.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<Category?> CreateCategoryAsync(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            var createdCategory = await _categoryRepository.CreateAsync(category);
            return createdCategory;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var isDeleted = await _categoryRepository.DeleteAsync(id);
            return isDeleted;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {

            var categories = await _categoryRepository.GetAllAsync();
            return categories;
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return null;
            }
            return category;
        }

        public async Task<IEnumerable<Category>> SearchCategoriesAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public async Task<Category?> UpdateCategoryAsync(int id, CategoryDTO categoryDTO)
        {
            var existingCategory = await _categoryRepository.GetByIdAsync(id);
            if (existingCategory == null)
            {
                return null; // Category not found
            }
            // Map the DTO to the existing category entity
            _mapper.Map(categoryDTO, existingCategory);
            var updatedCategory = await _categoryRepository.UpdateAsync(existingCategory);
            return updatedCategory;
        }
    }
}
