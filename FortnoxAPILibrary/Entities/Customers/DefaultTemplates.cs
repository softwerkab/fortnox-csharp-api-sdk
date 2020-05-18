using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "DefaultTemplates", PluralName = "DefaultTemplates")]
    public class DefaultTemplates
    {

        ///<summary> Default template for orders. Must be a name of an existing print template. </summary>
        [JsonProperty]
        public string Order { get; set; }

        ///<summary> Default template for offers. Must be a name of an existing print template. </summary>
        [JsonProperty]
        public string Offer { get; set; }

        ///<summary> Default template for invoices. Must be a name of an existing print template. </summary>
        [JsonProperty]
        public string Invoice { get; set; }

        ///<summary> Default template for cash invoices. Must be a name of an existing print template. </summary>
        [JsonProperty]
        public string CashInvoice { get; set; }
    }
}