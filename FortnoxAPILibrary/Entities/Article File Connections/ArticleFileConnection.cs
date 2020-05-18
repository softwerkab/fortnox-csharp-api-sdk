using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "ArticleFileConnection", PluralName = "ArticleFileConnections")]
    public class ArticleFileConnection
    {

        ///<summary> Direct URL to the record </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> Id of the file </summary>
        [JsonProperty]
        public string FileId { get; set; }

        ///<summary> Article number </summary>
        [JsonProperty]
        public string ArticleNumber { get; set; }
    }
}