using System.Collections.Generic;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

namespace FortnoxAPILibrary.Reused
{
    [Entity(SingularName = "EmailSenders")]
    public class EmailSenders
    {
        [JsonProperty]
        public List<TrustedEmailSender> TrustedSenders { get; set; }
        [JsonProperty]
        public List<TrustedEmailSender> RejectedSenders { get; set; }
    }
}
