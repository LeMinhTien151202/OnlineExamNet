
using ExamOnline.Interfaces.ICategory;

namespace ExamOnline.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Category?> CreateCategoryAsync(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            var createdCategory = await _unitOfWork.Categories.CreateAsync(category);
            return createdCategory;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var isDeleted = await _unitOfWork.Categories.DeleteAsync(id);
            return isDeleted;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {

            //var categories = await _categoryRepository.GetAllAsync();
            var categories = await _unitOfWork.Categories.GetAllAsync();
            return categories;
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);
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
            var existingCategory = await _unitOfWork.Categories.GetByIdAsync(id);
            if (existingCategory == null)
            {
                return null; // Category not found
            }
            // Map the DTO to the existing category entity
            _mapper.Map(categoryDTO, existingCategory);
            var updatedCategory = await _unitOfWork.Categories.UpdateAsync(existingCategory);
            return updatedCategory;
        }
    }
}
