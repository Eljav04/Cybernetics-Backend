
using System;
using Lesson_51_HT.Model;

namespace Lesson_51_HT.Controller
{
	public class ProductController
	{
        public List<Product> ProductData { get; set; }

        public ProductController()
		{
			ProductData = new();
		}

        public void AddProduct(Product new_product)
        {
            ProductData.Add(new_product);
        }

        public void AddProduct(params Product[] products)
        {
            foreach(Product product in products)
            {
                ProductData.Add(product);
            }
        }

        public Product? GetProductByID(int productID)
        {
            foreach (Product product in ProductData)
            {
                if (productID.Equals(product.ID))
                {
                    return product;
                }
            }
            return null;
        }
    }
}

