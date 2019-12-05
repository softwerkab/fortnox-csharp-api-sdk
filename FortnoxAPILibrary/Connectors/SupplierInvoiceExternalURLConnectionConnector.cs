using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class SupplierInvoiceExternalURLConnectionConnector : EntityConnector<SupplierInvoiceExternalURLConnection, SupplierInvoiceExternalURLConnection, Sort.By.SupplierInvoiceURLConnection>
    {
        /// <remarks/>
        public SupplierInvoiceExternalURLConnectionConnector()
        {
            Resource = "supplierinvoiceexternalurlconnections";
        }

        /// <remarks/>
        public SupplierInvoiceExternalURLConnection Get(string id)
        {
            return BaseGet(id);
        }

        /// <remarks/>
        public SupplierInvoiceExternalURLConnection Create(SupplierInvoiceExternalURLConnection supplierInvoiceExternalUrlConnection)
        {
            return BaseCreate(supplierInvoiceExternalUrlConnection);
        }

        /// <remarks/>
        public SupplierInvoiceExternalURLConnection Update(SupplierInvoiceExternalURLConnection supplierInvoiceExternalUrlConnection)
        {
            return BaseUpdate(supplierInvoiceExternalUrlConnection, supplierInvoiceExternalUrlConnection.Id);
        }

        /// <remarks/>
        public void Delete(string id)
        {
            BaseDelete(id);
        }
    }
}
