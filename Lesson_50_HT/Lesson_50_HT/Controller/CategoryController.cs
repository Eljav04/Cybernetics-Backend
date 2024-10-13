using System;
using Lesson_50_HT.Model;

namespace Lesson_50_HT.Controller
{
	internal class CategoryController
	{
		public List<Category> CategoriesList { get; set; }

		public CategoryController()
		{
			CategoriesList = new();
		}

		public void Add(Category category)
		{
			CategoriesList.Add(category);
		}

		public bool Delete(int _id)
		{
			foreach (Category category in CategoriesList)
			{
				if (category.)
			}
		}
	}
}

