using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FortnoxAPILibrary
{
	class RealValueAttribute : Attribute
	{
		public string RealValue { get; set; }

		public RealValueAttribute(string realValue)
		{
			this.RealValue = realValue;
		}
	}
}
