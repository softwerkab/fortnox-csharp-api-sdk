using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "InvoiceFileConnection", PluralName = "InvoiceFileConnections")]
    public class InvoiceFileConnection
    {

        ///<summary> ID of the document.  Can be used as “entityids” to fetch attachments from multiple entities </summary>
        [JsonProperty]
        public long? entityId { get; set; }

        ///<summary> Number of attachments on the document (also the ones set as not included for send) </summary>
        [ReadOnly]
        [JsonProperty]
        public long? numberOfAttachments { get; private set; }

        ///<summary> Document type (“F”, “O” or “OF”)  O = Orders  OF = Offers  F = Invoices </summary>
        [JsonProperty]
        public long? entityType { get; set; }

        ///<summary> ID of the file.  Use ArchiveFileId from Inbox/Archive endpoint in this field. </summary>
        [JsonProperty]
        public string fileId { get; set; }

        ///<summary> Flag if the attachment should be included on send or only visible in Fortnox </summary>
        [JsonProperty]
        public bool? includeOnSend { get; set; }

        ///<summary> ID of the connection. Used against Archive to fetch the file. </summary>
        [JsonProperty]
        public string id { get; set; }
    }
}