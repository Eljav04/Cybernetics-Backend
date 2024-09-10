using System;
using System.Collections;
using Errors_Class;
using InteractWithProducts_Class;
using Product_Class;
using ProductController_Class;

namespace Classes
{
    public class Program
    {
        public static void Main()
        {
            InteractWithProducts IWP = new();
            Errors errors = new();

            // Notebooks
            IWP.AddProductFunc(new ArrayList() { Category.Notebook, "Dell", "XPS 13", 999.99, "20" });
            IWP.AddProductFunc(new ArrayList() { Category.Notebook, "Apple", "MacBook Pro", 1299.99, "15" });
            IWP.AddProductFunc(new ArrayList() { Category.Notebook, "HP", "Spectre x360", 1099.99, "10" });
            IWP.AddProductFunc(new ArrayList() { Category.Notebook, "Lenovo", "ThinkPad X1 Carbon", 1399.99, "5" });
            IWP.AddProductFunc(new ArrayList() { Category.Notebook, "Asus", "ZenBook 14", 899.99, "8" });
            
            // Phones
            IWP.AddProductFunc(new ArrayList() { Category.Phone, "Samsung", "Galaxy S23", 799.99, "25" });
            IWP.AddProductFunc(new ArrayList() { Category.Phone, "Apple", "iPhone 14", 999.99, "30" });
            IWP.AddProductFunc(new ArrayList() { Category.Phone, "Google", "Pixel 7", 599.99, "20" });
            IWP.AddProductFunc(new ArrayList() { Category.Phone, "OnePlus", "9 Pro", 699.99, "10" });
            IWP.AddProductFunc(new ArrayList() { Category.Phone, "Xiaomi", "Mi 11", 499.99, "18" });

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
                        "3.Show total company price and quantity\n" +
                        "4.Show total price and quantity for category\n" +
                        "5.Add product\n" +
                        "6.Sell product\n" +
                        "7.Remove product\n" +
                        "8.Quit\n"
                        );
                    Console.Write("Choose option: ");
                    switch (Convert.ToString(Console.ReadLine()))
                    {
                        case "1":
                            IWP.ShowAllProducts();
                            break;
                        case "2":
                            IWP.ShowAllProductsByCategory();
                            break;
                        case "3":
                            IWP.ShowTotalPrice();
                            break;
                        case "4":
                            IWP.ShowTotalPriceForCategory();
                            break;
                        case "5":
                            ArrayList new_product = new();
                            if (IWP.CreateProduct(ref new_product))
                            {
                                IWP.AddProductFunc(new_product);
                                Console.Clear();
                                Console.WriteLine("Required contact added successfully");
                                Console.WriteLine("Push any key to continue...");
                                Console.ReadKey();
                            }
                            else
                            {
                                errors.MistakeError();
                            }
                            break;

                        case "6":
                            IWP.SellProduct();
                            break;
                        case "7":
                            IWP.RemoveProduct();
                            break;
                        case "8":
                            isContinue = false;
                            break;
                        default:
                            errors.NonexistentOptionError();
                            break;
                    }
                }
            }
        }
    }

    enum Category
    {
        Notebook = 1,
        Phone = 2,
    }

}