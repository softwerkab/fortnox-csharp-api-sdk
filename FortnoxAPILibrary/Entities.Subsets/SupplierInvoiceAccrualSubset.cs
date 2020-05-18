using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Entity(SingularName = "SupplierInvoiceAccrual", PluralName = "SupplierInvoiceAccruals")]
    public class SupplierInvoiceAccrualSubset
    {
        ///<summary> Direct URL to the record </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> Description of the accrual </summary>
        [JsonProperty]
        public string Description { get; set; }

        ///<summary> Invoice number </summary>
        [JsonProperty]
        public int? SupplierInvoiceNumber { get; set; }

        ///<summary> Type of period </summary>
        [JsonProperty]
        public string Period { get; set; }
    }
}
