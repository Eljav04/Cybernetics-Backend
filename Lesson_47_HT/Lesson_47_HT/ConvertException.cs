using System;
namespace Lesson_47_HT
{
	public class ConvertException : Exception
	{
		public ConvertException(): base("Please, use only digits!")
		{
		}
	}
}

