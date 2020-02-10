using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "AssetFileConnection", PluralName = "AssetFileConnections")]
    public class AssetFileConnection
    {

        ///<summary> Direct URL to the record </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> Id of the file </summary>
        [JsonProperty]
        public string Id { get; set; }

        ///<summary> Name of the file </summary>
        [ReadOnly]
        [JsonProperty]
        public string Name { get; private set; }

        ///<summary> Asset number </summary>
        [JsonProperty]
        public string AssetId { get; set; }
    }
}