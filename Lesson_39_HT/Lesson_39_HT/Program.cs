using System;
using Products_Class;
using Errors_Class;

namespace Classes {
    public class Program {
        public static void Main()
        {
            Products products = new Products();
            Errors errors = new Errors();
            intertactionWithProducts();

            // Loop that wait instructions from user and then implmenet required action
            void intertactionWithProducts()
            {
                bool isContinue = true;

                while (isContinue)
                {
                    Console.Clear();
                    Console.WriteLine(
                        "1.Show all products\n" +
                        "2.Show products by category\n" +
                        "3.Show total company price\n" +
                        "4.Show total price for category\n" +
                        "5.Add product\n" +
                        "6.Sell product\n" +
                        "7.Quit\n"
                        );
                    Console.Write("Choose option: ");
                    switch (Convert.ToString(Console.ReadLine()))
                    {
                        case "1":
                            products.ShowAllProducts();
                            Console.WriteLine("Push any key to continue...");
                            Console.ReadKey();
                            break;
                        case "2":
                            ShowProductsByCategoryFunc();
                            Console.WriteLine("Push any key to continue...");
                            Console.ReadKey();
                            break;
                        case "3":
                            products.ShowTotalCompanyPrice();
                            break;
                        case "4":
                            products.ShowTotalPriceForCategory();
                            break;
                        case "5":
                            AddProductFunc();
                            break;
                        case "6":
                            products.SellProduct();
                            break;
                        case "7":
                            isContinue = false;
                            break;
                        default:
                            errors.NonexistentOptionError();
                            break;
                    }
                }
            }

            void ShowProductsByCategoryFunc()
            {
                Console.Clear();
                Console.WriteLine(
                    "Which category do you want to show:\n" +
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

                products.ShowProductsByCategory(requiredCategory);
             
            };

            void AddProductFunc()
            {
                Console.Clear();
                Console.WriteLine(
                    "Which category do you want to add:\n" +
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
                products.AddProduct(requiredCategory);
            }

        }
    }

}