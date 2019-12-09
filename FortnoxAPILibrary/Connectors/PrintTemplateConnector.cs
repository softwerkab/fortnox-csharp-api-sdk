using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class PrintTemplateConnector : EntityConnector<PrintTemplate, EntityCollection<PrintTemplate>, Sort.By.PrintTemplate?>
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
		public EntityCollection<PrintTemplate> Find()
		{
			return BaseFind();
		}
	}
}
