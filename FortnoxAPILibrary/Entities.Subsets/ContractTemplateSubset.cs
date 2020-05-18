using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Entity(SingularName = "ContractTemplate", PluralName = "ContractTemplates")]
    public class ContractTemplateSubset
    {
        ///<summary> Direct URL to the record </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> Length of the contract </summary>
        [JsonProperty]
        public int? ContractLength { get; set; }

        ///<summary> Invoice interval </summary>
        [JsonProperty]
        public int? InvoiceInterval { get; set; }

        ///<summary> Name of the template </summary>
        [JsonProperty("ContractTemplateName")]
        public string TemplateName { get; set; }

        ///<summary> Number of the template </summary>
        [JsonProperty("ContractTemplateNumber")]
        public string TemplateNumber { get; set; }
    }
}
