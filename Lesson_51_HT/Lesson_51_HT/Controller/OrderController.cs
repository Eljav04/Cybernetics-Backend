using System;
using Lesson_51_HT.Model;

namespace Lesson_51_HT.Controller
{
	public class OrderController
	{
        public List<Order> OrdersData { get; set; }

        public OrderController()
        {
            OrdersData = new();
        }

        public void AddOrder(Order new_Order)
        {
            OrdersData.Add(new_Order);
        }

        public void AddOrder(params Order[] Orders)
        {
            foreach (Order Order in Orders)
            {
                OrdersData.Add(Order);
            }
        }
    }
}

