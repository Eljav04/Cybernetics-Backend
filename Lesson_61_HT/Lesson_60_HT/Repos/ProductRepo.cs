using System;
using Lesson_60_HT.Scaf_Models;
using Microsoft.EntityFrameworkCore;

namespace Lesson_60_HT.Repos
{
	public class ProductRepo
	{
		public List<Product> ProductsList { get; set; }
        public List<Category> CategoriesList { get; set; }



        public ProductRepo()
		{
			using var db = new ScafDbContext();

			// Lazy
			//CategoriesList = db.Categories.ToList();

			// Eager
			ProductsList = db.Products.Include(p => p.Category).ToList();


			// Explicit 
			//ProductsList.ForEach(pr =>
			//db.Entry(pr).Reference(p => p.Category).Load()
			//);
		}
	}
}

