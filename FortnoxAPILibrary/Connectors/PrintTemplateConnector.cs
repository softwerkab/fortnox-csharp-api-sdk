
using System.Collections.Generic;
using FortnoxAPILibrary.Entities;

namespace FortnoxAPILibrary.Connectors
{
	/// <remarks/>
	public class PrintTemplateConnector : EntityConnector<PrintTemplates, PrintTemplates, Sort.By.PrintTemplate>
	{
		/// <remarks/>
		public PrintTemplateConnector()
		{
			base.Resource = "printtemplates";
		}

		/// <summary>
		/// Gets a list of print templates
		/// </summary>
		/// <returns>A list of print templates</returns>
		public PrintTemplates Find()
		{
			return base.BaseFind();
		}
	}
}
