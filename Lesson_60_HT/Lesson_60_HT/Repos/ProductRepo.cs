using System;
using Lesson_60_HT.DAL;
using Lesson_60_HT.Models;
namespace Lesson_60_HT.Repos
{
	public class ProductRepo
	{
		public List<Product> ProductsList { get; set; }
        public List<Category> CategoriesList { get; set; }



        public ProductRepo()
		{
			using var db = new AppDbContext();

			CategoriesList = db.Categories.ToList();
			ProductsList = db.Products.ToList();
		}
	}
}

