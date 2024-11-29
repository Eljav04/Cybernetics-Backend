using System;
using Lesson_51_HT.Services.Autoincrement;

namespace Lesson_51_HT.Model
{
	public class Order
	{
        public int ID { get; }
        public DateTime Date { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public Order(
            DateTime Date,
            Customer Customer,
            Product Product,
            int Quantity
            )
		{
            this.ID = Autoincrement.GetOrderID();
            this.Date = Date;
            this.Customer = Customer;
            this.Product = Product;
            this.Quantity = Quantity;
		}
	}
}

