using System.Collections.Generic;
using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

namespace Fortnox.SDK.Entities;

public class EntityCollection<T>
{
    [GenericPropertyName]
    [JsonProperty]
    public IList<T> Entities { get; set; }

    [JsonProperty]
    internal MetaInformation MetaInformation { get; set; }

    /// <remarks/>
    public int TotalResources => MetaInformation.TotalResources;

    /// <remarks/>
    public int TotalPages => MetaInformation.TotalPages;

    /// <remarks/>
    public int CurrentPage => MetaInformation.CurrentPage;
}

public class MetaInformation
{
    [JsonProperty("@TotalResources")]
    public int TotalResources { get; set; }

    [JsonProperty("@TotalPages")]
    public int TotalPages { get; set; }

    [JsonProperty("@CurrentPage")]
    public int CurrentPage { get; set; }
}