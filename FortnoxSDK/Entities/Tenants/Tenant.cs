using Newtonsoft.Json;

namespace Fortnox.SDK.Entities.Tenants;

public class Tenant
{
    [JsonProperty("tenantId")]
    public long TenantId { get; set; }

    [JsonProperty("activated")]
    public bool WarehouseActivated { get; set; }
}
