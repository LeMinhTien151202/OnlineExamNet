namespace ExamOnline.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(int id);
        Task<Category?> CreateCategoryAsync(CategoryDTO categoryDTO);
        Task<Category?> UpdateCategoryAsync(int id, CategoryDTO categoryDTO);
        Task<bool> DeleteCategoryAsync(int id);
        Task<IEnumerable<Category>> SearchCategoriesAsync(string searchTerm);
    }
}
