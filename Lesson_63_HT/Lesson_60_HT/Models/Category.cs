using System;
namespace Lesson_60_HT.Models
{
	public class Category
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;

		ICollection<Product> Products { get; set; }

    }
}

