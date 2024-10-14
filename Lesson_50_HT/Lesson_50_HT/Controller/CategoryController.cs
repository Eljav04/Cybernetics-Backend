using System;
using Lesson_50_HT.Model;

namespace Lesson_50_HT.Controller
{
	internal class CategoryController
	{
		public List<Category> CategoriesList { get; set; }

		public CategoryController(List<Category> categoriesList)
		{
			CategoriesList = categoriesList;
		}

		public void Add(Category category)
		{
			CategoriesList.Add(category);
		}

		public bool Delete(int _id)
		{
			foreach (Category category in CategoriesList)
			{
				if (category.ID == _id)
				{
					CategoriesList.Remove(category);
					return true;
				}
			}
			return false;
		}

		public void ShowAll()
		{
			CategoriesList.ForEach(c => Console.WriteLine($"{c.ID} - {c.Name}"));
		}

		public List<Question>? GetQuestionsByCategoryID(int category_id)
		{
			foreach (Category category in CategoriesList)
			{
				if (category.ID == category_id)
				{
					return category.QuestionList;
				}
			}
			return null;
		}

		public bool IfCategortyExist(int category_id)
		{
            foreach (Category category in CategoriesList)
            {
                if (category.ID == category_id)
                {
					return true;
                }
            }
			return false;
        }

        public Category? GetCategotyByID(int categoty_id)
        {
            foreach (Category category in CategoriesList)
            {
                if (category.ID == categoty_id)
                {
					return category;
                }
            }
            return null;
        }
    }
}

