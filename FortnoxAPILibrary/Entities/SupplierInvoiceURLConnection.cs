using System.ComponentModel;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary
{
    /// <remarks/>
    public class SupplierInvoiceURLConnection
    {
        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
        public string Id { get; set; }

        /// <remarks/>
        public string SupplierInvoiceNumber { get; set; }

        /// <remarks/>
        public string URLConnection { get; set; }
    }
}
