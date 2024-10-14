using System;
using Lesson_50_HT.Services.AutoIncrement;

namespace Lesson_50_HT.Model
{
	internal class Category
	{
		public int ID { get; private set; }
		public List<Question> QuestionList { get; set; }
		public string Name { get; set; }

        public Category(string name)
		{
			ID = AutoIncrement.GetCategoryID();
			Name = name;
			QuestionList = new();
		}

        public Category()
        {
            ID = AutoIncrement.GetCategoryID();
        }


    }
}

