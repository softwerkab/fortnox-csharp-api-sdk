using System.ComponentModel;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    public class SupplierInvoiceExternalURLConnection
    {
        /// <summary>This field is Read-Only in Fortnox</summary>
        public string Id { get; private set; }

        /// <remarks/>
        public string SupplierInvoiceNumber { get; set; }

        /// <remarks/>
        public string ExternalURLConnection { get; set; }
    }
}
