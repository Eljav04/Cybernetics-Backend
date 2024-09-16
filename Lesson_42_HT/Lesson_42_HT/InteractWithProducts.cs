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
        public ArrayList categooris;

        public InteractWithProducts()
		{
            productController = new ProductController();
            errors = new Errors();
            categooris = productController.Categories;

    }
       
        //Patterns for Brand / Model / Price / Quantity
        private string[] CheckPatterns = {
            @"^[a-zA-Z]+$",
            @"^[a-zA-Z0-9\s]+$",
            @"^[0-9/,.]+$",
            @"^[0-9]+$",
        };

        // Enum class for product Categories
        enum Category
        {
            Notebook = 1,
            Phone = 2,
        }

        // Choose&Enter categoryfunctions
        public string ChooseCategory(string requiredCategory)
        {
            if (requiredCategory == "1")
            {
                return Convert.ToString(Category.Notebook);
            }
            else if (requiredCategory == "2")
            {
                return Convert.ToString(Category.Phone);
            }
            else
            {
                Console.WriteLine(categooris);
                return "";
            }
            
        }

        public void EnterCategory(string text)
        {
            Console.Clear();
            Console.WriteLine(
                $"{text}:\n" +
                $"{(int)Category.Notebook}. {Category.Notebook}s\n" +
                $"{(int)Category.Phone}. {Category.Phone}s\n"
                );

            Console.Write("Choose option: ");
        }

        // Main Functionality

        // 1. ShowAllProducts function
        public void ShowAllProducts()
        {
            productController.ShowAllProducts() ;   
            Console.WriteLine("Push any key to continue...");
            Console.ReadKey();
        }

        // 2. ShowAllProductsByCategory

        public void ShowAllProductsByCategory()
        {
            Console.Clear();
            EnterCategory("Which category do you want to show:");
            string? requiredCategory = ChooseCategory(Console.ReadLine());

            if (requiredCategory == "")
            {
                errors.NonexistentOptionError();
                return;
            }
            productController.ShowProductsByCategory(requiredCategory);
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

        // 6. SellProduct function
        public void SellProduct()
        {
            Console.Clear();
            EnterCategory("Product from which category do you want to sell:");
            string? requiredCategory = ChooseCategory(Console.ReadLine());

            if (requiredCategory == "")
            {
                errors.NonexistentOptionError();
                return;
            }

            productController.ShowProductsByCategory(requiredCategory);

            int enter_id;
            Console.Write("Enter the id of product which you want to sell: ");

            // Check if input string only contain numeric charecters
            string? input_value = Console.ReadLine();
            Regex num_regex = new Regex(CheckPatterns[3]);
            if (num_regex.IsMatch(input_value))
            {
                enter_id = Convert.ToInt32(input_value);

                // Check if entered id less than amount of product in list
                if (enter_id >= productController.ProductsData.Count)
                {
                    errors.ProductFindError();
                    return;
                }
            }
            else
            {
                errors.NonexistentOptionError();
                return;
            };

            // Show selected Product for sell
            Console.Clear();
            Product product = (Product)productController.ProductsData[enter_id];
            productController.ShowProduct(product, enter_id);

            int enter_count;
            Console.Write("Enter how much of product which you want to sell: ");

            // Check if input string only contain numeric charecters
            string? input_value_2 = Console.ReadLine();
            Regex num_regex_2 = new Regex(CheckPatterns[3]);
            if (num_regex.IsMatch(input_value_2))
            {
                enter_count = Convert.ToInt32(input_value_2);
            }
            else
            {
                errors.MistakeError();
                return;
            };

            ArrayList productData = productController.ProductsData; 
            if ((enter_id < productData.Count) && (enter_id >= 0))
            {
                if (requiredCategory.Equals(product.Category))
                {
                    if (product.SellProduct(enter_count))
                    {
                        Console.Clear();
                        Console.WriteLine("Required product successfully sold");
                        Console.WriteLine("Push any key to continue...");
                        Console.ReadKey();
                    }
                    else
                    {
                        errors.NotEnoughCount();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You don't have access for sell product from another category!");
                    Console.WriteLine("Push any key to continue...");
                    Console.ReadKey();
                }
            }
            else
            {
                errors.ProductFindError();
                return;
            }

        }

        // 7. RemoveProduct function
        public void RemoveProduct()
        {
            Console.Clear();
            EnterCategory("Product from which category do you want to remove:");
            string? requiredCategory = ChooseCategory(Console.ReadLine());

            if (requiredCategory == "")
            {
                errors.NonexistentOptionError();
                return;
            }

            productController.ShowProductsByCategory(requiredCategory);

            int enter_id;
            Console.Write("Enter the id of product which you want to remove: ");

            // Check if input string only contain numeric charecters
            string? input_value = Console.ReadLine();
            Regex num_regex = new Regex(CheckPatterns[3]);
            if (num_regex.IsMatch(input_value))
            {
                enter_id = Convert.ToInt32(input_value);

                // Check if entered id less than amount of product in list
                if (enter_id >= productController.ProductsData.Count)
                {
                    errors.ProductFindError();
                    return;
                }
            }
            else
            {
                errors.NonexistentOptionError();
                return;
            };

           
            Product product = (Product)productController.ProductsData[enter_id];

            //Check if equal choosen category and category of product
            ArrayList productData = productController.ProductsData;
            if (requiredCategory.Equals(product.Category))
            {
                if (productController.RemoveProduct(enter_id))
                {
                    // Show selected Product for remove
                    Console.Clear();
                    productController.ShowProduct(product, enter_id);
                    Console.WriteLine("Required product successfully removed");
                    Console.WriteLine("Push any key to continue...");
                    Console.ReadKey();
                    
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You don't have access for sell product from another category!");
                    Console.WriteLine("Push any key to continue...");
                    Console.ReadKey();
                }
            }
            else
            {
                errors.ProductFindError();
                return;
            }

        }
    }
}

