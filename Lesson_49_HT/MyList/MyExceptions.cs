using System;
namespace MyColection.Generic.Exceptions
{
	public class NaNSumExpception : Exception
	{
		public NaNSumExpception() : base(
			"Use only digits' types for sum function!")
		{
		}
	}

    public class NotEnoughElements : Exception
    {
        public NotEnoughElements(string message) :
			base( message)
        {
        }
    }

	public class MaxElementException: Exception
	{
        public MaxElementException(string message) :
                    base(message)
        {
        }
    }

    public class MinElementException : Exception
    {
        public MinElementException(string message) :
                    base(message)
        {
        }
    }

}

