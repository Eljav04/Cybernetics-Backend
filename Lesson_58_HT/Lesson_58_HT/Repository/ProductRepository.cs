using Lesson_58_HT.Models;
using Lesson_58_HT.Services;
using System.Data;

namespace Lesson_58_HT.Repository
{
    public static class ProductRepository
    {
        private static List<Product> ProductList = new()
        {
            new("Sony Playstation 4", 56, 850, "~/media/example_1.jpg"),
            new("Sofa Perla", 34, 2300, "~/media/example_2.jpg"),
            new("Nike Pro", 254, 210, "~/media/example_3.jpg"),
        };

        public static List<Product> GetProducts() => ProductList;

        public static void AddProduct(Product product) {
            product.ID = Autoincrement.GetProductID();
            ProductList.Add(product); 
        }

        public static Product? GetProductByID(int id)
        {
            return ProductList.FirstOrDefault(p => p.ID == id);
        }

        public static void DeleteByID(int id)
        {
            foreach(Product product in ProductList)
            {
                if(product.ID == id)
                {
                    ProductList.Remove(product);
                    return;
                }
            }
        }






    }
}
