using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Entity(SingularName = "SupplierInvoiceExternalURLConnection")]
    public class SupplierInvoiceExternalURLConnection
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
        public string ExternalURLConnection { get; set; }
    }
}
