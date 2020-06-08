using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "InvoiceFileConnection", PluralName = "InvoiceFileConnections")]
    public class InvoiceFileConnection
    {

        ///<summary> ID of the document.  Can be used as “entityids” to fetch attachments from multiple entities </summary>
        [JsonProperty("entityId")]
        public long? EntityId { get; set; }

        ///<summary> Number of attachments on the document (also the ones set as not included for send) </summary>
        [ReadOnly]
        [JsonProperty("numberOfAttachments")]
        public long? NumberOfAttachments { get; private set; }

        ///<summary> Document type (“F”, “O” or “OF”)  O = Orders  OF = Offers  F = Invoices </summary>
        [JsonProperty("entityType")]
        public EntityType? EntityType { get; set; }

        ///<summary> ID of the file.  Use ArchiveFileId from Inbox/Archive endpoint in this field. </summary>
        [JsonProperty("fileId")]
        public string FileId { get; set; }

        ///<summary> Flag if the attachment should be included on send or only visible in Fortnox </summary>
        [JsonProperty("includeOnSend")]
        public bool? IncludeOnSend { get; set; }

        ///<summary> ID of the connection. Used against Archive to fetch the file. </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public enum EntityType
    {
        /// <summary> Invoice </summary>
        [EnumMember(Value = "F")]
        Invoice,
        /// <summary> Order </summary>
        [EnumMember(Value = "O")]
        Order,
        /// <summary> Offer </summary>
        [EnumMember(Value = "OF")]
        Offer
    }
}