using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class SupplierInvoiceExternalURLConnectionConnector : EntityConnector<SupplierInvoiceExternalURLConnection, SupplierInvoiceExternalURLConnection, Sort.By.SupplierInvoiceURLConnection>
    {
        /// <remarks/>
        public SupplierInvoiceExternalURLConnectionConnector(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
            base.Resource = "supplierinvoiceexternalurlconnections";
        }

        /// <remarks/>
        public SupplierInvoiceExternalURLConnectionConnector() : this(null, null)
        {
        }

        /// <remarks/>
        public SupplierInvoiceExternalURLConnection Get(string id)
        {
            return base.BaseGet(id);
        }

        /// <remarks/>
        public SupplierInvoiceExternalURLConnection Create(SupplierInvoiceExternalURLConnection supplierInvoiceExternalUrlConnection)
        {
            return base.BaseCreate(supplierInvoiceExternalUrlConnection);
        }

        /// <remarks/>
        public SupplierInvoiceExternalURLConnection Update(SupplierInvoiceExternalURLConnection supplierInvoiceExternalUrlConnection)
        {
            return base.BaseUpdate(supplierInvoiceExternalUrlConnection, supplierInvoiceExternalUrlConnection.Id);
        }

        /// <remarks/>
        public void Delete(string id)
        {
            base.BaseDelete(id);
        }
    }
}
