using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class PrintTemplateConnector : EntityConnector<PrintTemplates, PrintTemplates, Sort.By.PrintTemplate?>
	{
		/// <remarks/>
		public PrintTemplateConnector()
		{
			Resource = "printtemplates";
		}

		/// <summary>
		/// Gets a list of print templates
		/// </summary>
		/// <returns>A list of print templates</returns>
		public PrintTemplates Find()
		{
			return BaseFind();
		}
	}
}
