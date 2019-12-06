using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class SupplierInvoiceURLConnectionConnector : EntityConnector<SupplierInvoiceURLConnection, SupplierInvoiceURLConnection, Sort.By.SupplierInvoiceURLConnection?>
    {
        /// <remarks/>
        public SupplierInvoiceURLConnectionConnector()
        {
            Resource = "supplierinvoiceurlconnections";
        }

        /// <summary>
        /// Gets an supplier invoice url connection based on id
        /// </summary>
        /// <param name="id">The id to find</param>
        /// <returns>The found connection</returns>
        public SupplierInvoiceURLConnection Get(string id)
        {
            return BaseGet(id);
        }

        /// <summary>
        /// Creates a new supplier invoice url connection
        /// </summary>
        /// <param name="supplierInvoiceUrlConnection">The supplier invoice url connection to create</param>
        /// <returns>The created supplier invoice url connection</returns>
        public SupplierInvoiceURLConnection Create(SupplierInvoiceURLConnection supplierInvoiceUrlConnection)
        {
            return BaseCreate(supplierInvoiceUrlConnection);
        }

        /// <summary>
        /// Deletes a supplier invoice url connection
        /// </summary>
        /// <param name="id">The id of the supplier invoice url connection to delete</param>
        /// <returns>If the supplier invoice url connection was deleted or not</returns>
        public void Delete(string id)
        {
            BaseDelete(id);
        }
    }
}
