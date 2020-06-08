using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "PrintTemplate", PluralName = "PrintTemplates")]
    public class PrintTemplate
    {

        ///<summary> Code of the template </summary>
        [ReadOnly]
        [JsonProperty]
        public string Template { get; private set; }

        ///<summary> Name of the template </summary>
        [ReadOnly]
        [JsonProperty]
        public string Name { get; private set; }
    }
}