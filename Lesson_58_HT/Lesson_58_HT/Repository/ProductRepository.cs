using Lesson_58_HT.Models;
using System.Data;

namespace Lesson_58_HT.Repository
{
    public static class ProductRepository
    {
        private static List<Product> ProductList = new();

        public static List<Product> GetProducts => ProductList;

        public static void AddProduct(Product product) { 
            ProductList.Add(product); 
        }




    }
}
