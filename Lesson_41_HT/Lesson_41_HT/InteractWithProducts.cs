using System;
using Product_Class;
using ProductController_Class;
using System.Collections;
using Errors_Class;
using System.Reflection;
using System.Text.RegularExpressions;

namespace InteractWithProducts_Class
{
    public class InteractWithProducts
	{
        // Creating new productController for interact with products list
        private ProductController productController;
        private Errors errors;
        public InteractWithProducts()
		{
            productController = new ProductController();
            errors = new Errors();
		}
       
        //Patterns for Brand / Model / Price / Quantity
        private string[] CheckPatterns = {
            @"^[a-zA-Z]+$",
            @"^[a-zA-Z0-9\s]+$",
            @"^[0-9/.]+$",
            @"^[0-9]+$",
        };

        // Choose&Enter categoryfunctions
        public string ChooseCategory(string requiredCategory)
        {
            if (requiredCategory == "1")
            {
                return "Notebook";
            }
            else if (requiredCategory == "2")
            {
                return "Phone";
            }
            else
            {
                return "";
            }
        }

        public void EnterCategory(string text)
        {
            Console.Clear();
            Console.WriteLine(
                $"{text}:\n" +
                "1. Notebooks\n" +
                "2. Phones\n"
                );

            Console.Write("Choose option: ");
        }

        // Main Functionality

        // 1. ShowAllProducts function
        public void ShowAllProducts()
        {
            ArrayList productsData = productController.ProductsData;
            ArrayList categories = productController.Categories;
            int counter = 0;

            Console.Clear();
            foreach(Product product in productsData)
            {
                Console.WriteLine($"Product_ID: {counter}");
                Console.WriteLine(
                    $"{categories[0]}: {product.Category}\n" +
                    $"{categories[1]}: {product.Brand}\n" +
                    $"{categories[2]}: {product.Model}\n" +
                    $"{categories[3]}: {product.Price}\n" +
                    $"{categories[4]}: {product.Quantity}\n"
                        );
                Console.WriteLine("==========================");
                counter++;
            }
            Console.WriteLine("Push any key to continue...");
            Console.ReadKey();
        }

        // 2. ShowAllProductsByCategory
        public void ShowAllProductsByCategory()
        {
            ArrayList productsData = productController.ProductsData;
            ArrayList categories = productController.Categories;
            int counter = 0;

            Console.Clear();
            EnterCategory("Which category do you want to show:");
            string? requiredCategory = ChooseCategory(Console.ReadLine());

            if (requiredCategory == "")
            {
                errors.NonexistentOptionError();
                return;
            }

            Console.Clear();
            foreach (Product product in productsData)
            {
                if (product.Category.Equals(requiredCategory))
                {
                    Console.WriteLine($"Product_ID: {counter}");
                    Console.WriteLine(
                        $"{categories[0]}: {product.Category}\n" +
                        $"{categories[1]}: {product.Brand}\n" +
                        $"{categories[2]}: {product.Model}\n" +
                        $"{categories[3]}: {product.Price}\n" +
                        $"{categories[4]}: {product.Quantity}\n"
                            );
                    Console.WriteLine("==========================");
                }
                    counter++;
            }
            Console.WriteLine("Push any key to continue...");
            Console.ReadKey();
        }

        // 3.ShowTotalCompanyPrice function
        public void ShowTotalPrice()
        {
            ArrayList ProductData = productController.ProductsData;
            double totalPrice = 0;
            int totalQuantity = 0;

            foreach (Product product in ProductData)
            {
                double currenPrice = product.Price;
                int currenQuantity = product.Quantity;
                totalPrice += currenPrice * currenQuantity;
                totalQuantity += currenQuantity;
            }
            Console.Clear();
            Console.WriteLine($"All product statistics: \n" +
                $"Total quantity: {totalQuantity} items \n" +
                $"Total ptice: {totalPrice:0.00}$ \n");
            Console.WriteLine("==========================");
            Console.WriteLine("Push any key to continue...");
            Console.ReadKey();
        }

        // 4.ShowTotalCompanyPriceByCategory function
        public void ShowTotalPriceForCategory()
        {
            Console.Clear();
            EnterCategory("Which categoies statistics do you want to show:");
            string? requiredCategory = ChooseCategory(Console.ReadLine());

            if (requiredCategory == "")
            {
                errors.NonexistentOptionError();
                return;
            }
            ArrayList ProductData = productController.ProductsData;
            double totalPrice = 0;
            int totalQuantity = 0;

            foreach (Product product in ProductData)
            {
                if (product.Category.Equals(requiredCategory))
                {
                    double currenPrice = product.Price;
                    int currenQuantity = product.Quantity;
                    totalPrice += currenPrice * currenQuantity;
                    totalQuantity += currenQuantity;
                }
            }
            Console.Clear();
            Console.WriteLine($"All product statistics: \n" +
                $"Total quantity: {totalQuantity} items \n" +
                $"Total ptice: {totalPrice:0.00}$ \n");
            Console.WriteLine("==========================");
            Console.WriteLine("Push any key to continue...");
            Console.ReadKey();

        }



        // 5. AddProduct function (Include CreateProduct func)

        public bool CreateProduct(ref ArrayList new_product)
		{
            Console.Clear();
            EnterCategory("Which category do you want to add:");
            string? requiredCategory = ChooseCategory(Console.ReadLine());

            if (requiredCategory == "")
            {
                return false;
            }

            new_product = new ArrayList()
            {
                requiredCategory
            };

            for (int i = 1; i < 5; i++)
            {
                ArrayList categories = productController.Categories;

                Console.Write($"Enter {categories[i]}: ");
                string? current_value = Convert.ToString(Console.ReadLine());

                Regex regex = new Regex(CheckPatterns[i - 1]);
                if (regex.IsMatch(current_value))
                {
                    new_product.Add(current_value);
              
                }
                else
                {
                    return false;
                };
            };
            return true;
        }

        public void AddProductFunc(ArrayList new_product)
        {
            Product added_product = new()
            {
                Category = Convert.ToString(new_product[0]),
                Brand = Convert.ToString(new_product[1]),
                Model = Convert.ToString(new_product[2]),
                Price = Convert.ToDouble(new_product[3]),
                Quantity = Convert.ToInt32(new_product[4])
            };

            productController.AddProduct(added_product); 
        }
	}
}

