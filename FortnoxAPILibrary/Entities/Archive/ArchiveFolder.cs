using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "Folder", PluralName = "Folders")]
    public class ArchiveFolder
    {

        ///<summary> Direct URL to the record </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> Unique email for the folder </summary>
        [ReadOnly]
        [JsonProperty]
        public string Email { get; private set; }

        ///<summary> List of files </summary>
        [ReadOnly]
        [JsonProperty]
        public List<ArchiveFile> Files { get; private set; }

        ///<summary> List of folders </summary>
        [ReadOnly]
        [JsonProperty]
        public List<ArchiveFolder> Folders { get; private set; }

        ///<summary> Id of the folder </summary>
        [ReadOnly]
        [JsonProperty]
        public string Id { get; private set; }

        ///<summary> Name of the folder </summary>
        [JsonProperty]
        public string Name { get; set; }
    }
}