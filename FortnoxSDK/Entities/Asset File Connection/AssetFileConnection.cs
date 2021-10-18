using System;
using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

namespace Fortnox.SDK.Entities
{
    [Entity(SingularName = "AssetFileConnection", PluralName = "AssetFileConnections")]
    public class AssetFileConnection
    {

        ///<summary> Direct URL to the record </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public Uri Url { get; private set; }

        ///<summary> Id of the file </summary>
        [JsonProperty]
        public string FileId { get; set; }

        ///<summary> Name of the file </summary>
        [ReadOnly]
        [JsonProperty]
        public string Name { get; private set; }

        ///<summary> Asset number </summary>
        [JsonProperty]
        public long? AssetId { get; set; }
    }
}