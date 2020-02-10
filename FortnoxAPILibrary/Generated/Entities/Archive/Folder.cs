using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "Folder", PluralName = "Folders")]
    public class Folder
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
        [JsonProperty]
        public List<File> Files { get; set; }

        ///<summary> List of folders </summary>
        [JsonProperty]
        public List<Folder> Folders { get; set; }

        ///<summary> Id of the folder </summary>
        [ReadOnly]
        [JsonProperty]
        public string Id { get; private set; }

        ///<summary> Name of the folder </summary>
        [JsonProperty]
        public string Name { get; set; }
    }
}