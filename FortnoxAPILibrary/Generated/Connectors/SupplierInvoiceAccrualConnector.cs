using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class SupplierInvoiceAccrualConnector : EntityConnector<SupplierInvoiceAccrual, EntityCollection<SupplierInvoiceAccrualSubset>, Sort.By.SupplierInvoiceAccrual?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.SupplierInvoiceAccrual? FilterBy { get; set; }


		/// <remarks/>
		public SupplierInvoiceAccrualConnector()
		{
			Resource = "supplierinvoiceaccruals";
		}

		/// <summary>
		/// Find a supplierInvoiceAccrual based on id
		/// </summary>
		/// <param name="id">Identifier of the supplierInvoiceAccrual to find</param>
		/// <returns>The found supplierInvoiceAccrual</returns>
		public SupplierInvoiceAccrual Get(string id)
		{
			return BaseGet(id);
		}

		/// <summary>
		/// Updates a supplierInvoiceAccrual
		/// </summary>
		/// <param name="supplierInvoiceAccrual">The supplierInvoiceAccrual to update</param>
		/// <returns>The updated supplierInvoiceAccrual</returns>
		public SupplierInvoiceAccrual Update(SupplierInvoiceAccrual supplierInvoiceAccrual)
		{
			return BaseUpdate(supplierInvoiceAccrual, supplierInvoiceAccrual.SupplierInvoiceNumber.ToString());
		}

		/// <summary>
		/// Creates a new supplierInvoiceAccrual
		/// </summary>
		/// <param name="supplierInvoiceAccrual">The supplierInvoiceAccrual to create</param>
		/// <returns>The created supplierInvoiceAccrual</returns>
		public SupplierInvoiceAccrual Create(SupplierInvoiceAccrual supplierInvoiceAccrual)
		{
			return BaseCreate(supplierInvoiceAccrual);
		}

		/// <summary>
		/// Deletes a supplierInvoiceAccrual
		/// </summary>
		/// <param name="id">Identifier of the supplierInvoiceAccrual to delete</param>
		public void Delete(string id)
		{
			BaseDelete(id);
		}

		/// <summary>
		/// Gets a list of supplierInvoiceAccruals
		/// </summary>
		/// <returns>A list of supplierInvoiceAccruals</returns>
		public EntityCollection<SupplierInvoiceAccrualSubset> Find()
		{
			return BaseFind();
		}
	}
}
