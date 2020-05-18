using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "ContractTemplate", PluralName = "ContractTemplates")]
    public class ContractTemplate
    {

        ///<summary> Direct URL to the record </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> Administration fee </summary>
        [JsonProperty]
        public decimal? AdministrationFee { get; set; }

        ///<summary> Length of the contract </summary>
        [JsonProperty]
        public int? ContractLength { get; set; }

        ///<summary> Freight </summary>
        [JsonProperty]
        public decimal? Freight { get; set; }

        ///<summary> Invoice interval </summary>
        [JsonProperty]
        public int? InvoiceInterval { get; set; }

        ///<summary> – </summary>
        [JsonProperty]
        public List<ContractTemplateInvoiceRow> InvoiceRows { get; set; }

        ///<summary> If the contract is continuous </summary>
        [JsonProperty]
        public bool? Continuous { get; set; }

        ///<summary> Our reference </summary>
        [JsonProperty]
        public string OurReference { get; set; }

        ///<summary> Print template code </summary>
        [JsonProperty]
        public string PrintTemplate { get; set; }

        ///<summary> Remarks </summary>
        [JsonProperty]
        public string Remarks { get; set; }

        ///<summary> Name of the template </summary>
        [JsonProperty]
        public string TemplateName { get; set; }

        ///<summary> Number of the template </summary>
        [JsonProperty]
        public string TemplateNumber { get; set; }

        ///<summary> Terms of delivery code </summary>
        [JsonProperty]
        public string TermsOfDelivery { get; set; }

        ///<summary> Terms of payment code </summary>
        [JsonProperty]
        public string TermsOfPayment { get; set; }

        ///<summary> Way of delivery code </summary>
        [JsonProperty]
        public string WayOfDelivery { get; set; }
    }
}