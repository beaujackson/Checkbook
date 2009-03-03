using System;
using System.Text;

namespace Checkbook
{
	/// <summary>
	/// Summary description for CBUtil.
	/// </summary>
	public class CBUtil
	{
		public CBUtil()
		{
		}

		public static string DoubleToCurrency(double amount)
		{	
			return amount.ToString("C");
		}

		public static double CurrencyToDouble(string amount)
		{
			StringBuilder numbers = new StringBuilder();

			foreach(char c in amount)
			{
				switch(c)
				{
					case '0':
					case '1':
					case '2':
					case '3':
					case '4':
					case '5':
					case '6':
					case '7':
					case '8':
					case '9':
					case '.':
						numbers.Append(c);
						break;

					default:
						break;
				}
			}

			if("" == numbers.ToString())
			{
				numbers.Append("0");
			}

			return Convert.ToDouble(numbers.ToString());
		}
	}
}
