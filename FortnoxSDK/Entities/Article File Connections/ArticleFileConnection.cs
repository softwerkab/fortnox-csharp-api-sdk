using System;
using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

namespace Fortnox.SDK.Entities;

[Entity(SingularName = "ArticleFileConnection", PluralName = "ArticleFileConnections")]
public class ArticleFileConnection
{

    ///<summary> Direct URL to the record </summary>
    [ReadOnly]
    [JsonProperty("@url")]
    public Uri Url { get; private set; }

    ///<summary> Id of the file </summary>
    [JsonProperty]
    public string FileId { get; set; }

    ///<summary> Article number </summary>
    [JsonProperty]
    public string ArticleNumber { get; set; }
}