﻿using System;
using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Collections;

// Creating jagged arrey for storage products
List<List<string>> ProductData = new()
{
new List<string> { "Category", "Brand", "Model", "Price", "Quantity" }
};


// Notebooks
ProductData.Add(new List<string>() { "Notebook", "Dell", "XPS 13", "999.99", "20" });
ProductData.Add(new List<string>() { "Notebook", "Apple", "MacBook Pro", "1299.99", "15" });
ProductData.Add(new List<string>() { "Notebook", "HP", "Spectre x360", "1099.99", "10" });
ProductData.Add(new List<string>() { "Notebook", "Lenovo", "ThinkPad X1 Carbon", "1399.99", "5" });
ProductData.Add(new List<string>() { "Notebook", "Asus", "ZenBook 14", "899.99", "8" });

//Phones
ProductData.Add(new List<string>() { "Phone", "Samsung", "Galaxy S23", "799.99", "25" });
ProductData.Add(new List<string>() { "Phone", "Apple", "iPhone 14", "999.99", "30" });
ProductData.Add(new List<string>() { "Phone", "Google", "Pixel 7", "599.99", "20" });
ProductData.Add(new List<string>() { "Phone", "OnePlus", "9 Pro", "699.99", "10" });
ProductData.Add(new List<string>() { "Phone", "Xiaomi", "Mi 11", "499.99", "18" });

//Patterns for Brand / Model / Price / Quantity
string[] CheckPatterns = {
    @"^[a-zA-Z]+$",
    @"^[a-zA-Z0-9\s]+$",
    @"^[0-9/.]+$",
    @"^[0-9]+$",
};

intertactionWithProducts:
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
        goto ShowAllProducts;
    case "2":
        goto ShowProductsByCategory;
    case "3":
        goto ShowTotalCompanyPrice;
    case "4":
        goto ShowTotalPriceForCategory;
    case "5":
        goto AddProduct;
    case "6":
        goto SellProduct;
    case "7":
        goto Quit;
    default:
        goto NonexistentOptionError;
}

// 1.ShowAllProducts function
ShowAllProducts:
Console.Clear();
for (int i = 1; i < ProductData.Count; i++)
{
    Console.WriteLine($"Product_ID: {i}");
    for (int j = 0; j < ProductData[i].Count; j++)
    {
        Console.WriteLine(
            $"{ProductData[0][j]}: {ProductData[i][j]}"
            );
    };
    Console.WriteLine("==========================");
};
Console.WriteLine("Push any key to continue...");
Console.ReadKey();
goto intertactionWithProducts;

// 2.ShowProductsByCategory function
ShowProductsByCategory:
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
    goto NonexistentOptionError;
};

Console.Clear();
for (int i = 1; i < ProductData.Count; i++)
{
    if (ProductData[i][0].Equals(requiredCategory))
    {
        Console.WriteLine($"Product_ID: {i}");
        for (int j = 0; j < ProductData[i].Count; j++)
        {

            Console.WriteLine(
                $"{ProductData[0][j]}: {ProductData[i][j]}"
                );

        };
        Console.WriteLine("==========================");
    }
};
Console.WriteLine("Push any key to continue...");
Console.ReadKey();
goto intertactionWithProducts;

// 3.ShowTotalCompanyPrice function
ShowTotalCompanyPrice:
double totalPrice = 0;
int totalQuantity = 0;

for (int i = 1; i < ProductData.Count; i++)
{
    double currenPrice = Convert.ToDouble(ProductData[i][3]);
    int currenQuantity = Convert.ToInt32(ProductData[i][4]);
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
goto intertactionWithProducts;


// 4.ShowTotalPriceForCategory function
ShowTotalPriceForCategory:
Console.Clear();
Console.WriteLine(
    "Which category statistics do you want to show:\n" +
    "1. Notebooks\n" +
    "2. Phones\n"
    );
Console.Write("Choose option: ");
requiredCategory = Console.ReadLine();

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
    goto NonexistentOptionError;
};

totalPrice = 0;
totalQuantity = 0;

for (int i = 1; i < ProductData.Count; i++)
{
    if (ProductData[i][0].Equals(requiredCategory))
    {
        double currenPrice = Convert.ToDouble(ProductData[i][3]);
        int currenQuantity = Convert.ToInt32(ProductData[i][4]);
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
goto intertactionWithProducts;



// 5.AddProduct function
AddProduct:
Console.Clear();
List<string> new_product = new List<string>();

Console.Clear();
Console.WriteLine(
    "Which category do you want to add:\n" +
    "1. Notebooks\n" +
    "2. Phones\n"
    );

Console.Write("Choose option: ");
requiredCategory = Console.ReadLine();

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
    goto NonexistentOptionError;
};

new_product.Add(requiredCategory);

for (int i = 1; i < 5; i++)
{
    Console.Write($"Enter {ProductData[0][i]}: ");
    string? current_value = Convert.ToString(Console.ReadLine());

    Regex regex = new Regex(CheckPatterns[i - 1]);
    if (regex.IsMatch(current_value))
    {
        new_product.Add(current_value);
    }
    else
    {
        goto MistakeError;
    };
};
ProductData.Add(new_product);
Console.Clear();
Console.WriteLine("Required contact added successfully");
Console.WriteLine("Push any key to continue...");
Console.ReadKey();
goto intertactionWithProducts;

// 6.SellProduct
SellProduct:
Console.Clear();
for (int i = 1; i < ProductData.Count; i++)
{
    Console.WriteLine($"Product_ID: {i}");
    for (int j = 0; j < ProductData[i].Count; j++)
    {
        Console.WriteLine(
            $"{ProductData[0][j]}: {ProductData[i][j]}"
            );
    };
    Console.WriteLine("==========================");
};
Console.Write("Enter the id of product which you want to sell: ");
int enter_id = Convert.ToInt32(Console.ReadLine());
if ((enter_id < ProductData.Count) && enter_id != 0)
{
    ProductData.RemoveAt(enter_id);
    Console.Clear();
    Console.WriteLine("Required product successfully sold");
    Console.WriteLine("Push any key to continue...");
    Console.ReadKey();
    goto intertactionWithProducts;
}
else
{
    goto ProductFindError;
}


// Show mistake error and interrupt implementing a process
MistakeError:
Console.Clear();
Console.WriteLine("You have a mistake! Please try again");
Console.ReadKey();
goto intertactionWithProducts;

// Show that choosen option is nonexistent and interrupt implementing a process
NonexistentOptionError:
Console.Clear();
Console.WriteLine(
    "You chose nonexistent option\n" +
    "Try again!"
    );
Console.ReadKey();
Console.Clear();
goto intertactionWithProducts;

// Show that required product сouldn't find in Product list
ProductFindError:
Console.Clear();
Console.WriteLine(
    "Couldn't find the required product\n" +
    "Try again!"
    );
Console.ReadKey();
Console.Clear();
goto intertactionWithProducts;

// 7. Quit function
Quit:
Console.Clear();