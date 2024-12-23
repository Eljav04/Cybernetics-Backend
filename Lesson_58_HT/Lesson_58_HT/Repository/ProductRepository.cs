using AutoMapper;
using Lesson_58_HT.Models;
using Lesson_58_HT.Services;
using System.Data;

namespace Lesson_58_HT.Repository
{
    public static class ProductRepository
    {
        private static List<Product> ProductList = new()
        {
            new("Sony Playstation 4", 56, 850, "~/media/example_1.jpg", 1),
            new("Sofa Perla", 34, 2300, "~/media/example_2.jpg", 2),
            new("Chanel", 254, 210, "~/media/example_8.jpg", 3),
        };

        public static List<Product> GetProducts() => ProductList;

        public static void AddProduct(Product product) {
            product.ID = Autoincrement.GetProductID();
            ProductList.Add(product); 
        }

        public static Product? GetProductByID(int? id)
        {
            return ProductList.FirstOrDefault(p => p.ID == id);
        }

        public static List<Product> GetProductByCategory(int? id)
        {
            return ProductList.Where(p => p.CategoryID == id).ToList();
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

        public static void Update(Product updated_product)
        {
            Product product = ProductList.FirstOrDefault(p => p.ID == updated_product.ID);

            product.Name = updated_product.Name;
            product.Price = updated_product.Price;
            product.Quantity = updated_product.Quantity;
            product.CategoryID = updated_product.CategoryID;
        }






    }
}
