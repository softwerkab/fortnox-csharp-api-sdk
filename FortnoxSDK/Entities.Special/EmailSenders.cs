using System.Collections.Generic;
using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

namespace Fortnox.SDK.Entities
{
    [Entity(SingularName = "EmailSenders")]
    public class EmailSenders
    {
        [JsonProperty]
        public IList<TrustedEmailSender> TrustedSenders { get; set; }
        [JsonProperty]
        public IList<TrustedEmailSender> RejectedSenders { get; set; }
    }
}
