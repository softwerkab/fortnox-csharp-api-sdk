using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "SupplierInvoiceFileConnection", PluralName = "SupplierInvoiceFileConnections")]
    public class SupplierInvoiceFileConnection
    {

        ///<summary> Direct URL to the record </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> Id of the file </summary>
        [JsonProperty]
        public string FileId { get; set; }

        ///<summary> Name of the file </summary>
        [ReadOnly]
        [JsonProperty]
        public string Name { get; private set; }

        ///<summary> Supplier invoice number </summary>
        [JsonProperty]
        public string SupplierInvoiceNumber { get; set; }

        ///<summary> Name of the supplier </summary>
        [ReadOnly]
        [JsonProperty]
        public string SupplierName { get; private set; }
    }
}