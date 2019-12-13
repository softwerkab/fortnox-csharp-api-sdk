using System;

namespace FortnoxAPILibrary
{
	public class StringValueAttribute : Attribute
	{
		public string RealValue { get; set; }

		public StringValueAttribute(string realValue)
		{
			RealValue = realValue;
		}
	}
}
