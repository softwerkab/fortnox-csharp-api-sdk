using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Entity(SingularName = "SupplierInvoiceURLConnection")]
    public class SupplierInvoiceURLConnection
    {
        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly]
        [JsonProperty]
        public string Id { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string SupplierInvoiceNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string URLConnection { get; set; }
    }
}
