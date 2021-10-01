using System;
using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Entities
{
    /// <remarks/>
    [Entity(SingularName = "ContractTemplate", PluralName = "ContractTemplates")]
    public class ContractTemplateSubset
    {
        ///<summary> Direct URL to the record </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public Uri Url { get; private set; }

        ///<summary> Length of the contract </summary>
        [JsonProperty]
        public long? ContractLength { get; set; }

        ///<summary> Invoice interval </summary>
        [JsonProperty]
        public long? InvoiceInterval { get; set; }

        ///<summary> Name of the template </summary>
        [JsonProperty("ContractTemplateName")]
        public string TemplateName { get; set; }

        ///<summary> Number of the template </summary>
        [JsonProperty("ContractTemplateNumber")]
        public string TemplateNumber { get; set; }
    }
}
