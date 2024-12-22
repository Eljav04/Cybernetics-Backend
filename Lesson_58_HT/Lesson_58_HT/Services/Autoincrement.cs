using System;
namespace Lesson_58_HT.Services
{
	public static class Autoincrement
	{
		public static int ProductId = 1;

		public static int GetProductID() => ProductId++;

	}
}

