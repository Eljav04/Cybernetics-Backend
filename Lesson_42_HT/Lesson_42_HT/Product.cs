using System;
using System.Collections;
using ProductController_Class;

namespace Product_Class
{
	public class Product
	{   
        // Creating properties
        public string? Category { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        //Sell function
        public bool SellProduct(int sellQuantity)
        {
            if (sellQuantity <= Quantity)
            {
                Quantity -= sellQuantity;          
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}

