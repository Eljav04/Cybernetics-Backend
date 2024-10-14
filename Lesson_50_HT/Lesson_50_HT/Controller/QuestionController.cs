using System;
using System.Threading.Channels;
using Lesson_50_HT.Model;
using Lesson_50_HT.Services.Messages;
using Lesson_50_HT.Services.Patterns;
namespace Lesson_50_HT.Controller
{
	internal static class QuestionController
	{

		public static int _default_answers_cout = 3;
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

		public static Question? Create(int answers_count)
		{
            Console.Write("Enter question: ");
			string? question_text = Console.ReadLine();
			if (question_text == "") {
				return null;
			}

			Question question = new();

			for (int i = 0; i < answers_count; i++)
			{
				Console.WriteLine($"Eneter {i+1} answer: ");
				string? new_answer = Console.ReadLine();
				if (new_answer != "")
				{
					question.Answers.Add(Console.ReadLine());
				}
				else
				{
					return null;
				}
			}

            Console.Write($"Eneter number of right answer: ");
            dynamic? right_answer = Console.ReadLine();

            if (!Patterns.RE_numeric.IsMatch(right_answer))
            {
                return null;
            }
            else
            {
                right_answer = Convert.ToInt32(right_answer);
            }

            if (right_answer > answers_count)
            {
                return null;
            }

            question.RightAnswerID = right_answer - 1;
			return question;
        }

        public static Question? Create()
        {
            Console.Write("Enter question: ");
            string? question_text = Console.ReadLine();
            if (question_text == "")
            {
                return null;
            }

            Question question = new();
			question.QuestionText = question_text;

            for (int i = 0; i < _default_answers_cout; i++)
            {
                Console.Write($"Eneter {i + 1} answer: ");
                string? new_answer = Console.ReadLine();
                if (new_answer != "")
                {
                    question.Answers.Add(new_answer);
                }
                else
                {
                    return null;
                }
            }

            Console.Write($"Eneter number of right answer: ");
            dynamic? right_answer = Console.ReadLine();

            if (!Patterns.RE_numeric.IsMatch(right_answer))
            {
                return null;
            }
            else
            {
                right_answer = Convert.ToInt32(right_answer);
            }

			if (right_answer > _default_answers_cout)
			{
				return null;
			}

            question.RightAnswerID = right_answer - 1;
            return question;
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

