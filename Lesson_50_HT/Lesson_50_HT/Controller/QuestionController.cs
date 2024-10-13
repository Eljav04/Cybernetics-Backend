using System;
using Lesson_50_HT.Model;
namespace Lesson_50_HT.Controller
{
	internal static class QuestionController
	{
		public static void Add(Category category, Question question)
		{
			category.QuestionList.Add(question);
		}

		public static bool Delete(Category category, int question_id)
		{
			foreach (Question question in category.QuestionList)
			{
				if (question.ID == question_id)
				{
					category.QuestionList.Remove(question);
					return true;
				}
			}
			return false;
		}

		public static void ShowAll(Category category)
		{
			category.QuestionList.ForEach(q => {
				q.ShowQuestion();
				Console.WriteLine($"Right answer: {q.RightAnswerID+1}");
				Console.WriteLine("=========================");
			});

		}
	}
}

