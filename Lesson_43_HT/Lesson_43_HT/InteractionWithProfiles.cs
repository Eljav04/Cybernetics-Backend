using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lesson_43_HT
{
    public class InteractionWithProfiles
    {
        // Creating new profileController for interact with profiles list
        public ProfileController profileController;
        public Errors errors;
        public InteractionWithProfiles()
        {
            profileController = new ProfileController();
            errors = new Errors();
        }

        //Patterns for Brand / Model / Price / Quantity
        private Hashtable CheckPatterns = new(){
            {"Name", @"^[a-zA-Z]+$" },
            {"Surname", @"^[a-zA-Z]+$" },
            {"Age", @"^[0-9]+$" },
            {"Email", @"^[A-Za-z0-9._%-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}" },
            {"Password", @"^[A-Za-z0-9._%-@#&*]+$" }
        };

        // Main Functionality
        // DeleteUser function
    //    public void DeleteUser()
    //    {
    //        Console.Clear();
    //        int enter_id;
    //        Console.Write("Enter the id of user which you want to remove: ");

    //        // Check if input string only contain numeric charecters
    //        string? input_value = Console.ReadLine();
    //        Regex num_regex = new Regex((string)CheckPatterns["Age"]);
    //        if (num_regex.IsMatch(input_value))
    //        {
    //            enter_id = Convert.ToInt32(input_value);

    //            // Check if entered id less than amount of profiles in list
    //            if (enter_id >= productController.ProductsData.Count)
    //            {
    //                errors.ProductFindError();
    //                return;
    //            }
    //        }
    //        else
    //        {
    //            errors.NonexistentOptionError();
    //            return;
    //        };


    //        Product product = (Product)productController.ProductsData[enter_id];

    //        //Check if equal choosen category and category of product
    //        ArrayList productData = productController.ProductsData;
    //        if (requiredCategory.Equals(product.Category))
    //        {
    //            if (productController.RemoveProduct(enter_id))
    //            {
    //                // Show selected Product for remove
    //                Console.Clear();
    //                productController.ShowProduct(product, enter_id);
    //                Console.WriteLine("Required product successfully removed");
    //                Console.WriteLine("Push any key to continue...");
    //                Console.ReadKey();

    //            }
    //            else
    //            {
    //                Console.Clear();
    //                Console.WriteLine("You don't have access for sell product from another category!");
    //                Console.WriteLine("Push any key to continue...");
    //                Console.ReadKey();
    //            }
    //        }
    //        else
    //        {
    //            errors.ProductFindError();
    //            return;
    //        }


    //    }
    //}
}