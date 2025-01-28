using Udemy.Entity;

namespace Udemy.DAL.Interfaces
{
    public interface ICategoryRepository
    {
        public List<Category> GetCategories();
        public Category GetCategoryById(int id);
        public void AddCategory(Category category);
        public void UpdateCategory(Category category);
        public void DeleteCategory(Category category);



    }
}
