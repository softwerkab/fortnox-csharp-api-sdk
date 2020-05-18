using System;
using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
	/// <remarks/>
	[Obsolete("Connector in currently not supported")]
	public class NoxFinansInvoiceConnector : EntityConnector<NoxFinansInvoice, EntityCollection<NoxFinansInvoiceSubset>, Sort.By.NoxFinansInvoice?>, INoxFinansInvoiceConnector
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.NoxFinansInvoice? FilterBy { get; set; }

        /// <remarks/>
		public NoxFinansInvoiceConnector()
		{
			Resource = "noxfinansinvoices";
		}
		/// <summary>
		/// Gets a list of noxFinansInvoices
		/// </summary>
		/// <returns>A list of noxFinansInvoices</returns>
		public EntityCollection<NoxFinansInvoiceSubset> Find()
		{
			return FindAsync().Result;
		}

		public async Task<EntityCollection<NoxFinansInvoiceSubset>> FindAsync()
		{
			return await BaseFind();
		}
	}
}
