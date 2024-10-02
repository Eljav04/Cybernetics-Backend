using System.Text.RegularExpressions;
namespace Lesson_47_HT
{
	public static class MyConvert
	{
		public static decimal ToDecimal(string requireValue)
		{
			Regex decimalRegex = new Regex(@"^[0-9]+[.,][0-9]+$");
            Regex intRegex = new Regex(@"^[0-9]+$");
            if (decimalRegex.IsMatch(requireValue))
			{
				return decimal.Parse(requireValue);
			}
			else if (intRegex.IsMatch(requireValue))
			{
                return decimal.Parse(requireValue);
            }

			throw new ConvertException();
        }
	}
}

