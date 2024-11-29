using System;
using Lesson_51_HT.Services;
using Lesson_51_HT.Services.Autoincrement;

namespace Lesson_51_HT.Model
{
	public class Product
	{
        public int ID { get; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int SellCount { get; set; }
        public Category CategoryName { get; set; }

        public Product(
            string Name, 
            decimal Price, 
            int Quantity, 
            int SellCount, 
            Category CategoryName
        )
		{
            this.ID = Autoincrement.GetProductID();
            this.Name = Name;
            this.Price = Price;
            this.Quantity = Quantity;
            this.SellCount = SellCount;
            this.CategoryName = CategoryName;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Product info: \n" +
                $"Name: {Name}, " +
                $"Price: {Price}, " +
                $"Quantity: {Quantity}, " +
                $"SellCount: {SellCount}, " +
                $"Category: {CategoryName.ToString()}\n" +
                $"=============================");
        }
    }

    
}

