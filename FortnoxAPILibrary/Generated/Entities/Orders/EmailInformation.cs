using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "EmailInformation", PluralName = "EmailInformation")]
    public class EmailInformation
    {

        ///<summary> Reply to adress. Must be a valid e-mail address </summary>
        [JsonProperty]
        public string EmailAddressFrom { get; set; }

        ///<summary> Customer e-mail address </summary>
        [JsonProperty]
        public string EmailAddressTo { get; set; }

        ///<summary> Customer e-mail address copy </summary>
        [JsonProperty]
        public string EmailAddressCC { get; set; }

        ///<summary> Customer e-mail address blind carbon copy </summary>
        [JsonProperty]
        public string EmailAddressBCC { get; set; }

        ///<summary> Subject of e-mail{-} in body = documentnumber{name} = customer name </summary>
        [JsonProperty]
        public string EmailSubject { get; set; }

        ///<summary> Body of e-mail.{-} in body = documentnumber{name} = customer name </summary>
        [JsonProperty]
        public string EmailBody { get; set; }
    }
}