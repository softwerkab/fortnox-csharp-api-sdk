using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FortnoxAPILibrary
{
	/// <remarks/>
	internal static class Extensions
	{
		/// <remarks/>
		public static object GetValue(this object obj, string propertyName)
		{
			return obj.GetType().GetProperty(propertyName).GetValue(obj, null);
		}
	}
}