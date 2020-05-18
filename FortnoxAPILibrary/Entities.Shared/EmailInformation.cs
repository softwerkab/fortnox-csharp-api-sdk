using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "EmailInformation", PluralName = "EmailInformation")]
    public class EmailInformation
    {

        ///<summary> Reply to adress. Must be a valid e-mail address </summary>
        [JsonProperty]
        public string EmailAddressFrom { get; set; }

        ///<summary> Customer e-mail address. Must be a valid e-mail address. </summary>
        [JsonProperty]
        public string EmailAddressTo { get; set; }

        ///<summary> Customer e-mail address – Copy. Must be a valid e-mail address. </summary>
        [JsonProperty]
        public string EmailAddressCC { get; set; }

        ///<summary> Customer e-mail address – Blind carbon copy. Must be a valid e-mail address. </summary>
        [JsonProperty]
        public string EmailAddressBCC { get; set; }

        ///<summary> Subject of the e-mail  The variable {no} = document number. The variable {name} = customer name </summary>
        [JsonProperty]
        public string EmailSubject { get; set; }

        ///<summary> Body of the e-mail. </summary>
        [JsonProperty]
        public string EmailBody { get; set; }
    }
}