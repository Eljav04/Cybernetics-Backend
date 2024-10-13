using System;

namespace Lesson_50_HT.Model
{
	internal class Category
	{
		public List<Question> QuestionList { get; set; }
		public string Name { get; set; }

        public Category(string name)
		{
			Name = name;
			QuestionList = new();
		}


	}
}

