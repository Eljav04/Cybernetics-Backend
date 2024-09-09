using System;
using Product_Class;
using System.Collections;
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
	}
}

