using System.ComponentModel;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary
{
    /// <remarks/>
    public class SupplierInvoiceExternalURLConnection
    {
        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
        public string Id { get; set; }

        /// <remarks/>
        public string SupplierInvoiceNumber { get; set; }

        /// <remarks/>
        public string ExternalURLConnection { get; set; }
    }
}
