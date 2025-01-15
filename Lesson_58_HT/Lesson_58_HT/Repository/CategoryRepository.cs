using Lesson_58_HT.Models;

namespace Lesson_58_HT.Repository
{
    public static class CategoryRepository
    {
        private static List<Categories> CategorisList = new()
        {
            new Categories(0, "All"),
            new Categories(1, "Electronics"),
            new Categories(2, "Furniture"),
            new Categories(3, "Health")
        };

        public static List<Categories> GetCategories() => CategorisList;

        public static Categories? GetCategoryByID(int id)
        {
            return CategorisList.FirstOrDefault(p => p.ID == id);
        }






    }
}
