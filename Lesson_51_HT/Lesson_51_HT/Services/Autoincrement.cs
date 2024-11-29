using System;
namespace Lesson_51_HT.Services.Autoincrement
{
	public static class Autoincrement
	{
		private static int ProductID = 1;
        private static int CustomerID = 1;
        private static int OrderID = 1;

        public static int GetProductID() => ProductID++;
        public static int GetCustomerID() => CustomerID++;
        public static int GetOrderID() => OrderID++;


    }
}

