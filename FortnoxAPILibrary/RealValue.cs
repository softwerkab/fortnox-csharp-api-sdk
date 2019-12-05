using System;

namespace FortnoxAPILibrary
{
	class RealValueAttribute : Attribute
	{
		public string RealValue { get; set; }

		public RealValueAttribute(string realValue)
		{
			RealValue = realValue;
		}
	}
}
