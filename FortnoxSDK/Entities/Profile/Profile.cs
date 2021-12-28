using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

namespace Fortnox.SDK.Entities;

[Entity(SingularName = "Me")]
public class Profile
{
    [JsonProperty]
    public string Id { get; set; }

    [JsonProperty]
    public string Name { get; set; }

    [JsonProperty]
    public string Email { get; set; }

    [JsonProperty]
    public bool SysAdmin { get; set; }

    [JsonProperty]
    public string Locale { get; set; }
}
