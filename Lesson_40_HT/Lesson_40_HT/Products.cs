using System;
using Errors_Class;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Products_Class
{
    public class Products
    {
        private Errors errors;
        public ArrayList ProductData;

        public Products(){
            errors = new Errors();

            ProductData = new()
            {
                new ArrayList() { "Category", "Brand", "Model", "Price", "Quantity" },

			    // Notebooks
			    new ArrayList() { "Notebook", "Dell", "XPS 13", "999.99", "20" },
                new ArrayList() { "Notebook", "Apple", "MacBook Pro", "1299.99", "15" },
                new ArrayList() { "Notebook", "HP", "Spectre x360", "1099.99", "10" },
                new ArrayList() { "Notebook", "Lenovo", "ThinkPad X1 Carbon", "1399.99", "5" },
                new ArrayList() { "Notebook", "Asus", "ZenBook 14", "899.99", "8" },

			    //Phones
			    new ArrayList() { "Phone", "Samsung", "Galaxy S23", "799.99", "25" },
                new ArrayList() { "Phone", "Apple", "iPhone 14", "999.99", "30" },
                new ArrayList() { "Phone", "Google", "Pixel 7", "599.99", "20" },
                new ArrayList() { "Phone", "OnePlus", "9 Pro", "699.99", "10" },
                new ArrayList() { "Phone", "Xiaomi", "Mi 11", "499.99", "18" }
            };
        }

        //Patterns for Brand / Model / Price / Quantity
        private string[] CheckPatterns = {
            @"^[a-zA-Z]+$",
            @"^[a-zA-Z0-9\s]+$",
            @"^[0-9/.]+$",
            @"^[0-9]+$",
        };

        // Choose category function
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
        
       
        // 1.ShowAllProducts function
        public void ShowAllProducts()
        {
            Console.Clear();
            for (int i = 1; i < ProductData.Count; i++)
            {
                Console.WriteLine($"Product_ID: {i}");

                ArrayList Categories = (ArrayList)ProductData[0];
                ArrayList Product = (ArrayList)ProductData[i];

                for (int j = 0; j < Product.Count; j++)
                {
                    Console.WriteLine(
                        $"{Categories[j]}: {Product[j]}"
                        );
                };
                Console.WriteLine("==========================");
            };
        }

        // 2.ShowProductsByCategory function
        public void ShowProductsByCategory(string requiredCategory)
        {
            Console.Clear();
            for (int i = 1; i < ProductData.Count; i++)
            {
                ArrayList Categories = (ArrayList)ProductData[0];
                ArrayList Product = (ArrayList)ProductData[i];

                if (Product[0].Equals(requiredCategory))
                {
                    Console.WriteLine($"Product_ID: {i}");
                    for (int j = 0; j < Product.Count; j++)
                    {

                        Console.WriteLine(
                            $"{Categories[j]}: {Product[j]}"
                            );
                    };
                    Console.WriteLine("==========================");
                }
            };

        }

        // 3.ShowTotalCompanyPrice function
        public void ShowTotalCompanyPrice()
        {
            double totalPrice = 0;
            int totalQuantity = 0;

            for (int i = 1; i < ProductData.Count; i++)
            {
                ArrayList Product = (ArrayList)ProductData[i];

                double currenPrice = Convert.ToDouble(Product[3]);
                int currenQuantity = Convert.ToInt32(Product[4]);
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

        // 4.ShowTotalPriceForCategory function
        public void ShowTotalPriceForCategory() {
            Console.Clear();
            Console.WriteLine(
                "Which category statistics do you want to show:\n" +
                "1. Notebooks\n" +
                "2. Phones\n"
                );
            Console.Write("Choose option: ");
            string? requiredCategory = Console.ReadLine();

            if (requiredCategory == "1")
            {
                requiredCategory = "Notebook";
            }
            else if (requiredCategory == "2")
            {
                requiredCategory = "Phone";
            }
            else
            {
                errors.NonexistentOptionError();
                return;
            };

            double totalPrice = 0;
            int totalQuantity = 0;

            for (int i = 1; i < ProductData.Count; i++)
            {
                ArrayList Product = (ArrayList)ProductData[i];
                if (Product[0].Equals(requiredCategory))
                {
                    double currenPrice = Convert.ToDouble(Product[3]);
                    int currenQuantity = Convert.ToInt32(Product[4]);
                    totalPrice += currenPrice * currenQuantity;
                    totalQuantity += currenQuantity;
                }
            };

            Console.Clear();
            Console.WriteLine($"{requiredCategory}s statistics: \n" +
                $"Total quantity: {totalQuantity} items \n" +
                $"Total ptice: {totalPrice:0.00}$ \n");
            Console.WriteLine("==========================");

            Console.WriteLine("Push any key to continue...");
            Console.ReadKey();
        }

        // 5.AddProduct function
        public void AddProduct(string requiredCategory)
        {
            Console.Clear();
            ArrayList new_product = new ArrayList()
            {
                requiredCategory
            };

            for (int i = 1; i < 5; i++)
            {
                ArrayList Categories = (ArrayList)ProductData[0];

                Console.Write($"Enter {Categories[i]}: ");
                string? current_value = Convert.ToString(Console.ReadLine());

                Regex regex = new Regex(CheckPatterns[i - 1]);
                if (regex.IsMatch(current_value))
                {
                    new_product.Add(current_value);
                }
                else
                {
                    errors.MistakeError();
                    return;
                };
            };
            ProductData.Add(new_product);
            Console.Clear();
            Console.WriteLine("Required contact added successfully");
            Console.WriteLine("Push any key to continue...");
            Console.ReadKey();
        }

        // 6.SellProduct
        public void SellProduct()
        {
            ShowAllProducts();

            int enter_id;
            Console.Write("Enter the id of product which you want to sell: ");

            // Check if input string only contain numeric charecters
            string? input_value = Console.ReadLine();
            Regex num_regex = new Regex(CheckPatterns[3]);
            if (num_regex.IsMatch(input_value))
            {
                enter_id = Convert.ToInt32(input_value);
            }
            else
            {
                errors.NonexistentOptionError();
                return;
            };

            if ((enter_id < ProductData.Count) && enter_id != 0)
            {
                ProductData.RemoveAt(enter_id);
                Console.Clear();
                Console.WriteLine("Required product successfully sold");
                Console.WriteLine("Push any key to continue...");
                Console.ReadKey();
            }
            else
            {
                errors.ProductFindError();
                return;
            }
        }

        // 7.SellProductByCategory function
        public void SellProductByCategory(string requiredCategory)
        {
            ShowProductsByCategory(requiredCategory);

            int enter_id;
            Console.Write("Enter the id of product which you want to sell: ");

            // Check if input string only contain numeric charecters
            string? input_value = Console.ReadLine();
            Regex num_regex = new Regex(CheckPatterns[3]);
            if (num_regex.IsMatch(input_value))
            {
                enter_id = Convert.ToInt32(input_value);
            }
            else
            {
                errors.NonexistentOptionError();
                return;
            };

            if ((enter_id < ProductData.Count) && enter_id != 0)
            {
                ArrayList Product = (ArrayList)ProductData[enter_id];

                if (requiredCategory.Equals(Product[0])){
                    ProductData.RemoveAt(enter_id);
                    Console.Clear();
                    Console.WriteLine("Required product successfully sold");
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

