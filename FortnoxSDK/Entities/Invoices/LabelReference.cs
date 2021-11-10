using Newtonsoft.Json;

namespace Fortnox.SDK.Entities;

public class LabelReference
{
    ///<summary> The ID of the label. </summary>
    [JsonProperty]
    public long? Id { get; set; }

    public LabelReference()
    {
    }

    public LabelReference(long? id)
    {
        Id = id;
    }
}