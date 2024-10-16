using System;
using Lesson_50_HT.Model;
namespace Lesson_50_HT.Controller
{
	internal static class ResultsController
	{
		public static void ShowAllResult(List<Result> resultsList)
		{
			Console.Clear();
            for (int i = 0; i < resultsList.Count; i++)
			{
                Result result = resultsList[i];
                result.ShowInfo();
				Console.WriteLine("======================");
			}
		}

	}
}

