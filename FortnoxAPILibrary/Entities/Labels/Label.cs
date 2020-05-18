using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "Label", PluralName = "Labels")]
    public class Label
    {

        ///<summary> The ID of the label. </summary>
        [ReadOnly]
        [JsonProperty]
        public int? Id { get; private set; }

        ///<summary> Description of the label </summary>
        [JsonProperty]
        public string Description { get; set; }
    }
}