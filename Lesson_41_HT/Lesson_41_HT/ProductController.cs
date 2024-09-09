using System;
using Product_Class;
using System.Collections;
using System.Diagnostics.Metrics;
using Errors_Class;
namespace ProductController_Class
{
	public class ProductController
	{

        public ArrayList Categories { get; }
        public ArrayList ProductsData { get; set; }

		public ProductController()
		{
			ProductsData = new ArrayList();
			Categories = new ArrayList() {
				"Category", "Brand", "Model", "Price", "Quantity"
			};
		}

		public void AddProduct(Product product)
		{
			ProductsData.Add(product);
		}

        public void ShowProduct(Product product, int counter)
        {
            Console.WriteLine($"Product_ID: {counter}");
            Console.WriteLine(
                $"{Categories[0]}: {product.Category}\n" +
                $"{Categories[1]}: {product.Brand}\n" +
                $"{Categories[2]}: {product.Model}\n" +
                $"{Categories[3]}: {product.Price}\n" +
                $"{Categories[4]}: {product.Quantity}\n"
                    );
            Console.WriteLine("==========================");
            
        }

		public void ShowAllProducts()
		{
            int counter = 0;
            Console.Clear();
            foreach (Product product in ProductsData)
            {
                ShowProduct(product, counter);
                counter++;
            }
        }

        public void ShowProductsByCategory(string requiredCategory)
        {
            int counter = 0;
            Console.Clear();
            foreach (Product product in ProductsData)
            {
                if (product.Category.Equals(requiredCategory))
                {
                    ShowProduct(product, counter);
                }
                counter++;
            }
        }

        public bool RemoveProduct(int productID)
        {
            if (productID < ProductsData.Count && productID >= 0)
            {
                ProductsData.RemoveAt(productID);
                return true;
            }
            return false;
        }
	}
}

