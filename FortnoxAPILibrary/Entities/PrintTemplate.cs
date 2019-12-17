using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Entity(SingularName = "PrintTemplate", PluralName = "PrintTemplates")]
    public class PrintTemplate 
    {
        /// <remarks/>
        [JsonProperty]
        public string Template { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Name { get; set; }
    }

    /// <remarks/>
    [Entity(SingularName = "PrintTemplate", PluralName = "PrintTemplates")]
    public class PrintTemplatesSubset
	{
        /// <remarks/>
		[JsonProperty]
		public string Template { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Name { get; set; }
    }
}
