using Microsoft.EntityFrameworkCore;
using Udemy.DAL.Interfaces;
using Udemy.Entity;

namespace Udemy.DAL
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddCategory(Category Category)
        {
            _context.Categories.Add(Category);
            _context.SaveChanges();

        }

        public void DeleteCategory(Category Category)
        {
            _context.Categories.Remove(Category);
            _context.SaveChanges();
        }

        public Category? GetCategoryById(int id) => _context.Categories.FirstOrDefault();

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public void UpdateCategory(Category Category)
        {
            _context.Categories.Update(Category);
            _context.SaveChanges();
        }
    }
}
